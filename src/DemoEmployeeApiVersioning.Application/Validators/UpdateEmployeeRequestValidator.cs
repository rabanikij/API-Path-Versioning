using DemoEmployeeApiVersioning.Domain.Entities;
using FluentValidation;

namespace DemoEmployeeApiVersioning.Application.Validators;


public sealed class UpdateEmployeeRequestValidator : AbstractValidator<Employee>
{
    public UpdateEmployeeRequestValidator()
    {
        RuleFor(x => x.Department)
            .NotEmpty()
            .MaximumLength(100);
    }
}