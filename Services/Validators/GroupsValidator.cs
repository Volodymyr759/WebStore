using Domain.Models.Groups;
using FluentValidation;

namespace Services.Validators
{
    /// <summary>
    /// Валідатор груп
    /// </summary>
    public class GroupsValidator : AbstractValidator<IGroupsModel>
    {
        /// <summary>
        /// Конструктор валідатора груп
        /// </summary>
        public GroupsValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Введіть назву від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви від 1 до 100 символів.");
            RuleFor(g => g.Number)
                .NotEmpty().WithMessage("Введіть номер групи від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина номеру групи від 1 до 100 символів.");
            RuleFor(g => g.Identifier)
                .NotEmpty().WithMessage("Введіть ідентифікатор групи від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина ідентифікатору групи від 1 до 100 символів.");
            RuleFor(g => g.AncestorNumber)
                .NotEmpty().WithMessage("Введіть номер групи-предка від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина номеру групи-предка від 1 до 100 символів.");
            RuleFor(g => g.AncestorIdentifier)
                .NotEmpty().WithMessage("Введіть ідентифікатору групи-предка від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина ідентифікатору групи-предка від 1 до 100 символів.");
            RuleFor(g => g.ProductType)
                .NotEmpty().WithMessage("Введіть тип товару (1 символ).")
                .Length(1).WithMessage("Довжина типу товару - 1 символ.");
            RuleFor(u => u.Link)
                .NotEmpty().WithMessage("Введіть посилання від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання від 1 до 300 символів.");
            RuleFor(u => u.Notes)
                .NotEmpty().WithMessage("Введіть опис від 1 до 500 символів.")
                .Length(1, 500).WithMessage("Довжина опису від 1 до 500 символів.");
        }
    }
}
