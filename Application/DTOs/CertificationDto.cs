using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CertificationDto
    {
        [Required]
        public string Name { get; set; }
        public string? TheIssuingOrganization { get; set; }
        public DateTime DateOfReceipt { get; set; }
    }
}
