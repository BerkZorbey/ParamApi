using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class AllergyValidator : AbstractValidator<AllergyDto>
    {
        public AllergyValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(25);
        }
    }
}
