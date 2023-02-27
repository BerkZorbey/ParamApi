using Domain.Base;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public virtual List<DoctorLanguage>? DoctorLanguages { get; set; }
        public virtual List<LanguageNurse>? LanguageNurses { get; set; }
    }
}
