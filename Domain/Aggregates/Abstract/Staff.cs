using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Abstract
{
    public abstract class Staff : Person
    {
        public DateTime Joined { get; set; }
        public List<Education>? Educations { get; set; }
        public List<Certification>? Certifications { get; set; }
        
    }
}
