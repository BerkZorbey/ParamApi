using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Log
    {
        public int Id { get; set; } = 1;
        public string? LogMessage { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
