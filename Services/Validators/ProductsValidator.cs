using Domain.Models.Products;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор товарів
    /// </summary>
    public class ProductsValidator : AbstractValidator<IProductsModel>
    {
        /// <summary>
        /// Конструктор валідатора товарів
        /// </summary>
        public ProductsValidator()
        {
            RuleFor(p => p.NameWebStore)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть власну назву від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина власної назви від 1 до 100 символів.");
            RuleFor(p => p.NameSupplier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть назву товару у постачальника від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви товару у постачальника від 1 до 100 символів.");
            RuleFor(p => p.SupplierId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Оберіть постачальника.")
                .GreaterThan(0).WithMessage("Не обрано постачальника.");
            RuleFor(p => p.CategoryId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Оберіть категорію.")
                .GreaterThan(0).WithMessage("Не обрано категорію.");
            RuleFor(p => p.UnitId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Оберіть одиницю виміру.")
                .GreaterThan(0).WithMessage("Не обрано одиницю виміру.");
            RuleFor(p => p.PriceWebStore)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Вкажіть власну ціну товару.")
                .GreaterThan(0).WithMessage("Не обрано вказано власну ціну товару.");
            RuleFor(p => p.PriceSupplier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Вкажіть ціну постачальника.")
                .GreaterThan(0).WithMessage("Не вказано ціну постачальника.");
            RuleFor(p => p.Available)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Вкажіть доступність товару (1 символ).")
                .Length(1).WithMessage("Не вказано доступність товару (1 символ).");
            RuleFor(p => p.LinkSupplier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть посилання від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання від 1 до 300 символів.");
            //RuleFor(u => u.Notes)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotEmpty().WithMessage("Введіть опис від 1 до 500 символів.")
            //    .Length(1, 500).WithMessage("Довжина опису від 1 до 500 символів.");
        }
    }
}
