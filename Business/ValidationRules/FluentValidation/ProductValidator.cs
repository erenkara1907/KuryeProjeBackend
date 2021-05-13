using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Code).NotEmpty().WithMessage("Lütfen 4 haneli bir kod girin");
            RuleFor(p => p.Code).MaximumLength(4).WithMessage("Girdiğiniz kod maximum 4 haneli olmalıdır.");
            RuleFor(p => p.Code).MinimumLength(4).WithMessage("Girdiğiniz kod minimum 4 haneli olmalıdır.");
        }
    }
}
