﻿using FluentValidation;

namespace eHospitalServer.Application.Features.Rooms.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(p => p.Number)
            .NotEmpty().WithMessage("Room number must not be empty.");

        RuleFor(p => p.Capacity)
            .GreaterThanOrEqualTo((byte)1).WithMessage("Capacity must be at least 1.")
            .LessThanOrEqualTo((byte)100).WithMessage("Capacity must be less than or equal to 100.");
    }
}