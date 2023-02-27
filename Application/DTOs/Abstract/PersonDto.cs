using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Abstract
{
    public abstract class PersonDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        [EmailAddress]
        public string? Email { get; set; }
        public string? IdentityNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        [Phone]
        public string? Phone { get; set; }

    }
}
