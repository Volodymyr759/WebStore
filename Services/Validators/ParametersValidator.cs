using Domain.Models.Parameters;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор характеристик
    /// </summary>
    public class ParametersValidator : AbstractValidator<IParametersModel>
    {
        /// <summary>
        /// Конструктор валідатора характеристик
        /// </summary>
        public ParametersValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Введіть назву характеристики від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви характеристики від 1 до 100 символів.");
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("Оберіть товар для характеристики.")
                .GreaterThan(0).WithMessage("Не обрано товар для характеристики.");
            RuleFor(p => p.UnitId)
                .NotEmpty().WithMessage("Оберіть одиницю виміру характеристики.")
                .GreaterThan(0).WithMessage("Не обрано одиницю виміру характеристики.");
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("Введіть значення характеристики від 1 до 20 символів.")
                .Length(1, 20).WithMessage("Довжина значення характеристики від 1 до 20 символів.");

        }
    }
}
