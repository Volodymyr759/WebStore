using Domain.Models.Units;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validators
{
    public class UnitsValidator : AbstractValidator<IUnitsModel>
    {
        public UnitsValidator()
        {
            RuleFor(u => u.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть назву від 1 до 3 символів.")
                .Length(1, 3).WithMessage("Довжина назви від 1 до 3 символів.");
            RuleFor(u => u.Notes)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть опис від 1 до 20 символів.")
                .Length(1, 20).WithMessage("Довжина опису від 1 до 20 символів.");
        }
    }
}
