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
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть назву від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина назви від 1 до 100 символів.");
            RuleFor(g => g.Number)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть номер групи від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина номеру групи від 1 до 100 символів.");
            RuleFor(g => g.Identifier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть ідентифікатор групи від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина ідентифікатору групи від 1 до 100 символів.");
            RuleFor(g => g.AncestorNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть номер групи-предка від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина номеру групи-предка від 1 до 100 символів.");
            RuleFor(g => g.AncestorIdentifier)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть ідентифікатору групи-предка від 1 до 100 символів.")
                .Length(1, 100).WithMessage("Довжина ідентифікатору групи-предка від 1 до 100 символів.");
            RuleFor(g => g.ProductType)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть тип товару (1 символ).")
                .Length(1).WithMessage("Довжина типу товару - 1 символ.");
            RuleFor(u => u.Link)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть посилання від 1 до 300 символів.")
                .Length(1, 300).WithMessage("Довжина посилання від 1 до 300 символів.");
            RuleFor(u => u.Notes)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Введіть опис від 1 до 500 символів.")
                .Length(1, 500).WithMessage("Довжина опису від 1 до 500 символів.");
        }
    }
}
