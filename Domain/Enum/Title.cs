using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public class Title
    {
        public enum Titles
        {
            Practitioner_Doctor = 1,
            Specialist,
            Operator_Doctor,
            Assistant_Professor,
            Associate_Professor,
            Professor,
            Ordinary
        }
    }
}
