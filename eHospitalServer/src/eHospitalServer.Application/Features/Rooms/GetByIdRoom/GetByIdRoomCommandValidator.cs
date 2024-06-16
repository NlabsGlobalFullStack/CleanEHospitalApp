using FluentValidation;

namespace eHospitalServer.Application.Features.Rooms.GetByIdRoom;

public class GetByIdRoomCommandValidator : AbstractValidator<GetByIdRoomCommand>
{
    public GetByIdRoomCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("OdaId cannot be empty!");
    }
}
