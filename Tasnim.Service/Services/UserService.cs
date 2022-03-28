using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.Configurations;
using Tasnim.Service.DTOs;
using Tasnim.Service.Interfaces;

namespace Tasnim.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private Mapper userMapper;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            var configUser = new MapperConfiguration(
                cfg => cfg
                .CreateMap<UserForRegistrationDto, User>()
                .ReverseMap());

            userMapper = new Mapper(configUser);
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

            var result = userMapper.Map<UserForRegistrationDto, User>(userDto);

            result.Password = HashPassword.Create(result.Password);

            await userRepository.CreateAsync(result);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<User>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            var existUser = await userRepository.GetAsync(expression);

            if(existUser is not null)
            {
                response.Error = new ErrorModel(404, "User is not found!");
                return response;
            }

            var result = await userRepository.UpdateAsync(existUser);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<User>>();

            var users = await userRepository.GetAllAsync(expression);

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

            response.Data = user;

            return response;
        }

        public async Task<BaseResponse<User>> UpdateAsync(long id, UserForRegistrationDto userDto)
        {
            var response = new BaseResponse<User>();

            // check for exist student
            var user = await userRepository.GetAsync(p => p.Id == id);
            if (user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            response.Data = userMapper.Map<UserForRegistrationDto, User>(userDto);

            return response;
        }
    }
}
