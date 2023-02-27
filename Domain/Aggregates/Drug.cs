using Domain.Base;
using Domain.Entities;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Drug : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual List<DrugPrescription>? DrugPrescriptions { get; set; }
    }
}
