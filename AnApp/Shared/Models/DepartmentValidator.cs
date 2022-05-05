using FluentValidation;

namespace AnApp.Shared.Models
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(department => department.Name).NotEmpty().WithMessage("Name is a required field.")
                .Length(5, 50).WithMessage("Name must be between 5 and 50 characters.");
            RuleFor(department => department.Description).NotEmpty().WithMessage("Description is a required field.")
                .Length(5, 50).WithMessage("Description must be between 5 and 50 characters.");

        }
    }
}