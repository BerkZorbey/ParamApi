using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DrugDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
