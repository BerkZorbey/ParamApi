using Domain.Aggregates.Abstract;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum.Title;

namespace Domain.Aggregates
{
    public class Doctor : Staff
    {
        public List<DoctorSpecialty>? DoctorSpecialties { get; set; }
        public List<DoctorLanguage>? DoctorLanguages { get; set; }
        public Titles Title { get; set; }
    }
}
