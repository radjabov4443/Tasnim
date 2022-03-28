using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim.Data.Contexts
{
    internal class TasnimDbContext : DbContext
    {
        public TasnimDbContext(DbContextOptions<TasnimDbContext> options) : base(options)
        {
        }
    }
}
