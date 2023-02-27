using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Abstract;
using Domain.ValueObject;

namespace Domain.Aggregates
{
    public class Nurse : Staff
    {
        public List<LanguageNurse>? LanguageNurses { get; set; }
    }
}
