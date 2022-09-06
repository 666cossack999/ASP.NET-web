using EmployeeService.Models.Requests;
using FluentValidation;

namespace EmployeeService.Models.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => )
        }
    }
}
