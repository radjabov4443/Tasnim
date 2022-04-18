using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Mentors;
using Tasnim.Domain.Entities.Posts;
using Tasnim.Service.Configurations;
using Tasnim.Service.DTOs;
using Tasnim.Service.Helpers;
using Tasnim.Service.Interfaces;

namespace Tasnim.Service.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMentorRepository mentorRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        private readonly string host;
        public MentorService(
            IMentorRepository mentorRepository,
            IMapper mapper,
            IConfiguration config,
            IWebHostEnvironment env)
        {
            this.mentorRepository = mentorRepository;
            this.mapper = mapper;
            this.config = config;
            this.env = env;
            this.host =
                $"https://{HttpContextHelper.Context.Request.Host.Value}/" +
                $"{config.GetSection("Storage:ImageUrl").Value}/";
        }
        public async Task<BaseResponse<Mentor>> CreateAsync(MentorForRegistrationDto mentorDto)
        {
            var response = new BaseResponse<Mentor>();

            var existMentor = await mentorRepository.GetAsync(p => p.Email == mentorDto.Email);

            if (existMentor is not null)
            {
                response.Error = new ErrorModel(400, "Mentor is exist");
                return response;
            }

            var result = mapper.Map<Mentor>(mentorDto);

            

            result.Password = HashPassword.Create(result.Password);

            await mentorRepository.CreateAsync(result);

            result.Image = host + result.Image;

            response.Data = result;

            return response;
        }

        public Task<BaseResponse<Mentor>> DeleteAsync(Expression<Func<Mentor, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IQueryable<Mentor>>> GetAllAsync(Expression<Func<Mentor, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Mentor>> GetAsync(Expression<Func<Mentor, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFilesAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }

        public Task<BaseResponse<Mentor>> UpdateAsync(long id, MentorForRegistrationDto MentorDto)
        {
            throw new NotImplementedException();
        }
    }
}
