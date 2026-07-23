using DemoEmployeeApiVersioning.Domain.Entities;
using FluentValidation;

namespace DemoEmployeeApiVersioning.Application.Validators;


public sealed class CreateEmployeeRequestValidator : AbstractValidator<Employee>
{
    public CreateEmployeeRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(120)
            .EmailAddress();
    }
}