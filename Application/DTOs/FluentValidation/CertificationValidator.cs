using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class CertificationValidator : AbstractValidator<CertificationDto>
    {
        public CertificationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
