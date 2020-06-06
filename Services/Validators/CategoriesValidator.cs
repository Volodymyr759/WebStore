using Domain.Models.Categories;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор категорій
    /// </summary>
    public class CategoriesValidator : AbstractValidator<ICategoriesModel>
    {
        /// <summary>
        /// Конструктор валідатора категорій
        /// </summary>
        public CategoriesValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Введіть назву від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви від 1 до 100 символів.");
            RuleFor(u => u.SupplierId)
                .NotEmpty().WithMessage("Оберіть постачальника.")
                .GreaterThan(0).WithMessage("Не обрано постачальника.");
            RuleFor(u => u.Link)
                .NotEmpty().WithMessage("Введіть посилання від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання від 1 до 300 символів.");
            RuleFor(u => u.Rate)
                .NotEmpty().WithMessage("Введіть націнку > 0.")
                .GreaterThan(0).WithMessage("Не введено націнку.");
            RuleFor(u => u.Notes)
                .NotEmpty().WithMessage("Введіть опис від 1 до 500 символів.")
                .Length(1, 500).WithMessage("Довжина опису від 1 до 500 символів.");
        }
    }
}
