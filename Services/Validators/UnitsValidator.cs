using Domain.Models.Units;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор одиниць виміру
    /// </summary>
    public class UnitsValidator : AbstractValidator<IUnitsModel>
    {
        /// <summary>
        /// Конструктор валідатора одиниць виміру
        /// </summary>
        public UnitsValidator()
        {
            RuleFor(u => u.Name)
                //.Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть назву від 1 до 3 символів.")
                .Length(1, 3).WithMessage("Довжина назви від 1 до 3 символів.");
            RuleFor(u => u.Notes)
                //.Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть опис від 1 до 20 символів.")
                .Length(1, 20).WithMessage("Довжина опису від 1 до 20 символів.");
        }
    }
}
