using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Abstract
{
    public abstract class StaffDto : PersonDto
    {
        [Required]
        public DateTime Joined { get; set; }
        public List<EducationDto>? Educations { get; set; }
        public List<CertificationDto>? Certifications { get; set; }
        public List<LanguageDto>? Languages { get; set; }
    }
}
