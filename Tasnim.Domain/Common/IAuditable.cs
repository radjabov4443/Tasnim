using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim.Domain.Common
{
    internal interface IAuditable
    {
        public long Id { get; set; }
    }
}
