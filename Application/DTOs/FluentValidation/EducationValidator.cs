using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class EducationValidator : AbstractValidator<EducationDto>
    {
        public EducationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Degree).NotEmpty().NotNull();
            RuleFor(x => x.Department).NotEmpty().NotNull();
            RuleFor(x => x.StartingDate).LessThan(DateTime.Now);
        }
    }
}
