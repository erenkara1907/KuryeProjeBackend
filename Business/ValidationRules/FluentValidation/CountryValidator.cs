using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CountryValidator:AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Ülke adı zorunludur");
        }
    }
}
