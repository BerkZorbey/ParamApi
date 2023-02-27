﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FluentValidation
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Accepted).NotNull().NotEmpty();
            RuleFor(x=>x.IdentityNo).NotNull().NotEmpty();
            RuleFor(x=>x.Email).EmailAddress();
            RuleFor(x => x.Phone).Length(10);
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now);
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
