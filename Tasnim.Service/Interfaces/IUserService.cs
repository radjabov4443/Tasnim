using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.DTOs;

namespace Tasnim.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(UserForRegistrationDto userDto);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<IQueryable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<BaseResponse<User>> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<User>> UpdateAsync(long id, UserForRegistrationDto userDto);
    }
}
