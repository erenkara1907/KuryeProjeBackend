using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.AddressDetail).NotEmpty().WithMessage("Adres detayı zorunludur.");
            RuleFor(a => a.PostalCode).NotEmpty().WithMessage("Posta kodu zorunludur.");
        }
    }
}
