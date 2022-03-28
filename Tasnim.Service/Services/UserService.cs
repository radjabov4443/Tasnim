using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.DTOs;
using Tasnim.Service.Interfaces;

namespace Tasnim.Service.Services
{
    public class UserService : IUserService
    {
        public Task<BaseResponse<User>> CreateAsync(UserForRegistrationDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> UpdateAsync(Guid id, UserForRegistrationDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
