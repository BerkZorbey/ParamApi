using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Certification : BaseEntity
    {
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public string? Name { get; set; }
        public string? TheIssuingOrganization { get; set; }
        public DateTime DateOfReceipt { get; set; }
    }
}
