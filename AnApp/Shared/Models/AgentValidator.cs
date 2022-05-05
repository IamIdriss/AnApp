using FluentValidation;

namespace AnApp.Shared.Models
{
    public class AgentValidator : AbstractValidator<Agent>
    {
        public AgentValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(agent => agent.FirstName).NotEmpty().WithMessage("First name is a required field.")
                .Length(3, 50).WithMessage("First name must be between 3 and 50 characters.");
            RuleFor(agent => agent.LastName).NotEmpty().WithMessage("Last name is a required field.")
                .Length(3, 50).WithMessage("Last name must be between 3 and 50 characters.");
            RuleFor(agent => agent.Gender).IsInEnum()
                .WithMessage("Gender is a required field.");
            RuleFor(agent => agent.PhoneNumber).NotEmpty().WithMessage("Phone number is a required field.")
                .Length(5, 50).WithMessage("Phone number must be between 5 and 50 characters.");
            RuleFor(agent => agent.Departments).NotEmpty().WithMessage("You have to define at least one address per agent");
            RuleForEach(agent => agent.Departments).SetValidator(new DepartmentValidator());
        }
    }
}