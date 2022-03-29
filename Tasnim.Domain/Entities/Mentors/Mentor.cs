﻿using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Mentors
{
    public class Mentor : IAuditable
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}