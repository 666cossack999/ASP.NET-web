using EmployeeService.Models.Requests;
using FluentValidation;

namespace EmployeeService.Models.Validators
{
    public class CreateEmployeeTypeRequestValidator : AbstractValidator<CreateEmployeeTypeRequest>
    {
        public CreateEmployeeTypeRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .Length(2, 255);
        }
    }
}
