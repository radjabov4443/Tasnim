using System;
using System.Text.Json.Serialization;
using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Statements
{
    public class Statement : IAuditable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime DeletedDate { get; set; }
    }
}
