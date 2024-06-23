using FluentValidation;

namespace eHospitalServer.Application.Features.Departments.UpdateDepartment;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Department name cannot be empty or null!");
        RuleFor(p => p.Name).MinimumLength(4).WithMessage("Department name must be at least 4 characters long!");
    }
}
