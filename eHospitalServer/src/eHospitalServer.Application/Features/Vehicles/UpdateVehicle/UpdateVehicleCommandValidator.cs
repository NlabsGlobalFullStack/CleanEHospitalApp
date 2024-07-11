using FluentValidation;

namespace eHospitalServer.Application.Features.Vehicles.UpdateVehicle;

public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(p => p.Plate)
            .MinimumLength(3)
            .WithMessage("The plate cannot be empty!");

        RuleFor(p => p.Capacity)
            .GreaterThanOrEqualTo((byte)1).WithMessage("Capacity must be at least 1.")
            .LessThanOrEqualTo((byte)100).WithMessage("Capacity must be less than or equal to 100.");
    }
}