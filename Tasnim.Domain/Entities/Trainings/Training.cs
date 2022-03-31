using System;
using System.Collections.Generic;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Mentors;

namespace Tasnim.Domain.Entities.Trainings
{
    public class Training : IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Mentor> Mentors { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
