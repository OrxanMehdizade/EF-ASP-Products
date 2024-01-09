using FluentValidation;

namespace EF_ASP_Products.Models.ViewModels.FluentValidations
{
    public class ProductFluentValidator:AbstractValidator<ProductAddViewModel>
    {
        public ProductFluentValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");



            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price is required.")
                .Must(check).WithMessage("Price must be a numeric value.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
        private bool check(decimal value)
        {
            return true;
        }
    }
}
