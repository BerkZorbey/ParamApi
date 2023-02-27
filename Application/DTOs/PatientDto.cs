using Application.DTOs.Abstract;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDto : PersonDto
    {
        [Required]
        public DateTime Accepted { get; set; }
        public string? Sickness { get; set; }
        public List<AllergyDto>? Allergies { get; set; }
    }
}
