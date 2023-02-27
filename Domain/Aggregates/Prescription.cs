using Domain.Base;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Prescription : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? Diagnosis { get; set; }
        public List<DrugPrescription>? DrugPrescriptions { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
