using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class DrugValidator : AbstractValidator<DrugDto>
    {
        public DrugValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty();
        }
    }
}
