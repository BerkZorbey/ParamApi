using Application.DTOs.Abstract;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum.Title;

namespace Application.DTOs
{
    public class DoctorDto : StaffDto
    {
        public List<SpecialtyDto>? Specialties { get; set; }
        public Titles Title { get; set; }
    }
}
