using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class AllergyPatient
    {
        public int Id { get; set; }
        public int AllergiyId;
        public Allergy? Allergy;
        public int PatientId;
        public Patient? Patient;
    }
}
