using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class LanguageNurse
    {
        public int Id { get; set; }
        public int NurseId { get; set; }
        public Nurse? Nurse { get; set; }
        public int LanguageId { get; set; }
        public Language? Language { get; set; }
    }
}
