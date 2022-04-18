using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Mentors;
using Tasnim.Service.DTOs;

namespace Tasnim.Service.Interfaces
{
    public interface IMentorService
    {
        Task<BaseResponse<Mentor>> CreateAsync(MentorForRegistrationDto mentorDto);
        Task<BaseResponse<Mentor>> GetAsync(Expression<Func<Mentor, bool>> expression);
        Task<BaseResponse<IQueryable<Mentor>>> GetAllAsync(Expression<Func<Mentor, bool>> expression = null);
        Task<BaseResponse<Mentor>> DeleteAsync(Expression<Func<Mentor, bool>> expression);
        Task<BaseResponse<Mentor>> UpdateAsync(long id, MentorForRegistrationDto MentorDto);
        Task<string> SaveFilesAsync(Stream file, string fileName);
    }
}
