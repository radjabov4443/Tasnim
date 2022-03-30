using AutoMapper;
using System;
using System.Linq;
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
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
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

            result.Password = HashPassword.Create(result.Password);

            await userRepository.CreateAsync(result);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<User>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var response = new BaseResponse<User>();

            var user = await userRepository.GetAsync(expression);

            if(user is null)
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
            
            var user = await userRepository.GetAsync(p => p.Id == id);

            if (user is null)
            {
                response.Error = new ErrorModel(404, "User not found");
                return response;
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.BirthDate = userDto.BirthDate;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Password = HashPassword.Create(userDto.Password);
            user.TestAnswers = userDto.TestAnswers;
            user.Update();

            await userRepository.UpdateAsync(user);

            response.Data = user;

            return response;
        }
    }
}
