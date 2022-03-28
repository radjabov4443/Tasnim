using System;
using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Trainings
{
    public class Training : IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
