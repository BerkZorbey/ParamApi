using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Education : BaseEntity
    {
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public string? Name { get; set; }
        public string? Degree { get; set; }
        public string? Department { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
