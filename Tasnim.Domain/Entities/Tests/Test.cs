
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Tests
{
    public class Test : IAuditable
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Tag { get; set; }
    }
}
