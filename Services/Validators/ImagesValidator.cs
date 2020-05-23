using Domain.Models.Images;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор зображень
    /// </summary>
    public class ImagesValidator : AbstractValidator<IImagesModel>
    {
        /// <summary>
        /// Конструктор валідатора зображень
        /// </summary>
        public ImagesValidator()
        {
            RuleFor(i => i.FileName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть назву файлу від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви файлу від 1 до 100 символів.");
            RuleFor(i => i.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Оберіть товар для зображення.")
                .GreaterThan(0).WithMessage("Не обрано товар для зображення.");
            //RuleFor(i => i.LinkWebStore)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotEmpty().WithMessage("Введіть посилання сайту на зображення від 1 до 300 символів.")
            //    .Length(1, 300).WithMessage("Довжина посилання сайту на зображення від 1 до 300 символів.");
            RuleFor(i => i.LinkSupplier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть посилання сайту постачальника на зображення від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання сайту постачальника на зображення від 1 до 300 символів.");
            RuleFor(i => i.LocalPath)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть локальний шлях від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина локальний шлях від 1 до 300 символів.");
        }
    }
}
