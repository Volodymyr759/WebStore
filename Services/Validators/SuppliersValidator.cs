using Domain.Models.Suppliers;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор постачальників
    /// </summary>
    public class SuppliersValidator : AbstractValidator<ISuppliersModel>
    {
        /// <summary>
        /// Конструктор валідатора постачальників
        /// </summary>
        public SuppliersValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Введіть назву від 1 до 20 символів.")
                .Length(1, 20).WithMessage("Довжина назви від 1 до 20 символів.");
            RuleFor(u => u.Link)
                .NotEmpty().WithMessage("Введіть посилання від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання від 1 до 300 символів.");
            RuleFor(u => u.Currency)
                .NotEmpty().WithMessage("Введіть валюту постачальника від 1 до 3 символів.")
                .Length(1, 3).WithMessage("Довжина назви валюти постачальника від 1 до 3 символів.");
            RuleFor(u => u.Notes)
                .NotEmpty().WithMessage("Введіть опис від 1 до 500 символів.")
                .Length(1, 500).WithMessage("Довжина опису від 1 до 500 символів.");
        }
    }
}
