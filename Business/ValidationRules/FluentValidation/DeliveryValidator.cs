using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DeliveryValidator:AbstractValidator<Delivery>
    {
        public DeliveryValidator()
        {
            RuleFor(d => d.Vehicle).NotEmpty().WithMessage("Araç seçimi yapınız lütfen");
        }
    }
}
