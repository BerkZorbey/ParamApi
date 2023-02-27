using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class PatientPhoneValidator : AbstractValidator<PatientPhoneDto>
    {
        public PatientPhoneValidator()
        {
            RuleFor(x => x.Phone).Length(10);
        }
    }
}
