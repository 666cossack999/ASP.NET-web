using EmployeeService.Models.Requests;
using FluentValidation;

namespace EmployeeService.Models.Validators
    
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .Length(1, 20);

            RuleFor(x => x.Surname)
                .NotNull()
                .Length(1, 25);

            RuleFor(x => x.Patronymic)
                .NotNull()
                .Length(2, 25);

            RuleFor(x => x.Salary)
                .NotNull();

            RuleFor(x => x.DepartmentId)
                .NotNull();

            RuleFor(x => x.EmployeeTypeId)
                .NotNull();               

        }
    }
}
