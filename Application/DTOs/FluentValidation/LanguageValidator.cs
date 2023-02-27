using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class LanguageValidator : AbstractValidator<LanguageDto>
    {
        public LanguageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Level).NotEmpty().NotNull();
        }
    }
}
