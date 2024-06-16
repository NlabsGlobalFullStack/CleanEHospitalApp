using FluentValidation;

namespace eHospitalServer.Application.Features.Departments.CreateDepartment;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("The department cannot be empty!");
        RuleFor(p => p.Name).MinimumLength(4).WithMessage("Department must be a minimum of 4 characters!");
        RuleFor(p => p.Name).MaximumLength(60).WithMessage("Department must be a maximum of 60 characters!");
    }
}