using AutoMapper;
using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Tests;

namespace Tasnim.Data.Repositories.Services
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        private readonly IMapper mapper;

        public TestRepository(TasnimDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }

    }
}