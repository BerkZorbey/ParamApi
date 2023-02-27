using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PrescriptionDto
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public string? Diagnosis { get; set; }
        public List<DrugDto>? Drugs { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
