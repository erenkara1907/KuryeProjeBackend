using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ReceiverValidator:AbstractValidator<Receiver>
    {
        public ReceiverValidator()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Alıcının E-Mail adresi girilmelidir.");
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("Alıcının adı girilmelidir");
            RuleFor(r => r.LastName).NotEmpty().WithMessage("Alıcının soyadı girilmelidir.");
            RuleFor(r => r.Phone).NotEmpty().WithMessage("Alıcının telefon numarası girilmelidir.");

        }
    }
}
