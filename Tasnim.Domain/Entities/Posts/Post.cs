using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Posts
{
    public class Post : IAuditable
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
