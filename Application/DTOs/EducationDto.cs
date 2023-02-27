using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EducationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Department { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
