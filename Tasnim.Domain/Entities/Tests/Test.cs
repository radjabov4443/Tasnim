using Newtonsoft.Json;
using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Tests
{
    public class Test : IAuditable
    {
        public long Id { get; set; }
        public string Tag { get; set; }
    }
}
