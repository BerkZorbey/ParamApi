using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class PrescriptionValidator : AbstractValidator<PrescriptionDto>
    {
        public PrescriptionValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty().NotNull();
            RuleFor(x => x.DoctorId).NotEmpty().NotNull();
        }
    }
}
