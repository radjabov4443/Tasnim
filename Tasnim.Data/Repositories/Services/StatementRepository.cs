using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Statements;

namespace Tasnim.Data.Repositories.Services
{
    public class StatementRepository : GenericRepository<Statement>, IStatementRepository
    {
        public StatementRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}