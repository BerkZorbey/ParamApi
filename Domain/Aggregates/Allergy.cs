using Domain.Base;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Allergy : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual List<AllergyPatient>? AllergyPatients { get; set; }
    }
}
