using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class DrugPrescription
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public Drug? Drug { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
