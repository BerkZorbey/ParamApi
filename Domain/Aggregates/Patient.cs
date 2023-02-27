using Domain.Aggregates.Abstract;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Patient : Person
    {
        public DateTime Accepted { get; set; }
        public string? Sickness { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
        public List<AllergyPatient>? AllergyPatients { get; set; }
    }
}
