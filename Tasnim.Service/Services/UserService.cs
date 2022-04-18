using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.Configurations;
using Tasnim.Service.DTOs;
using Tasnim.Service.Helpers;
using Tasnim.Service.Interfaces;

namespace Tasnim.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        private readonly string host;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper, 
            IConfiguration config, 
            IWebHostEnvironment env)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.config = config;
            this.env = env;
            this.host = 
                $"https://{HttpContextHelper.Context.Request.Host.Value}/" +
                $"{config.GetSection("Storage:ImageUrl").Value}/";
        }

        public async Task<BaseResponse<User>> CreateAsync(UserForRegistrationDto userDto)
        {
            var response = new BaseResponse<User>();

            var existUser = await userRepository.GetAsync(p => p.Email == userDto.Email);

            if (existUser is not null)
            {
                response.Error = new ErrorModel(400, "User is exist");
                return response;
            }

            var result = mapper.Map<User>(userDto);

            var url = await SaveImageAsync(userDto.Image.OpenReadStream(), userDto.Image.FileName);

            result.Image = 

            result.Password = HashPassword.Create(result.Password);

            await userRepository.CreateAsync(result);

            result.Image = host + result.Image;

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<User>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            var user = await userRepository.GetAsync(expression);

            if (user is null)
            {
                response.Error = new ErrorModel(404, "User is not found!");
                return response;
            }

            user.Delete();

            var result = await userRepository.UpdateAsync(user);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<IQueryable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            var response = new BaseResponse<IQueryable<User>>();

            var users = await userRepository.GetAllAsync(expression);

            if (users is null)
            {
                response.Error = new ErrorModel(204, "No Content");
                return response;
            }

            foreach (var user in users)
            {
                if(user.Image is not null)
                    user.Image = host + user.Image;
            }

            response.Data = users;

            return response;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            var user = await userRepository.GetAsync(expression);
            if (user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            if (user.Image is not null)
                user.Image = host + user.Image;

            response.Data = user;

            return response;
        }

        public async Task<string> SaveImageAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;

            string storagePath = config.GetSection("Storage:ImageUrl").Value;

            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");

            FileStream mainFile = File.Create(filePath);

            await file.CopyToAsync(mainFile);

            mainFile.Close();

            return fileName;
        }

        public async Task<BaseResponse<User>> UpdateAsync(long id, UserForRegistrationDto userDto)
        {
            var response = new BaseResponse<User>();

            var user = mapper.Map<User>(userDto);
            user.Update();

            var result = await userRepository.UpdateAsync(user);

            if (result is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            response.Data = user;

            return response;
        }
    }
}
