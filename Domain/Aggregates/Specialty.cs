using Domain.Base;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<DoctorSpecialty>? DoctorSpecialties { get; set; }

    }
}
