using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.GetByUserId;

internal sealed class GetByUserIdQueryHandler
    (
        IUserRepository userRepository,
        IDoctorRepository doctorRepository,
        INurseRepository nurseRepository,
        IEmployeeRepository employeeRepository,
        IPatientRepository patientRepository
    ) : IRequestHandler<GetByUserIdQuery, Result<UserResponse>>
{
    public async Task<Result<UserResponse>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        var doctor = await doctorRepository.GetByExpressionAsync(p => p.UserId == user.Id, cancellationToken);
        var nurse = await nurseRepository.GetByExpressionAsync(p => p.UserId == user.Id, cancellationToken);
        var employee = await employeeRepository.GetByExpressionAsync(p => p.UserId == user.Id, cancellationToken);
        var patient = await patientRepository.GetByExpressionAsync(p => p.UserId == user.Id, cancellationToken);
        if (user is null)
        {
            return Result<UserResponse>.Failure($"User with Id {request.Id} not found.");
        }

        var _userType = 0;
        if (doctor is not null)
        {
            _userType = 1;
            user.Doctor = doctor;
        }
        else if (nurse is not null)
        {
            _userType = 2;
            user.Nurse = nurse;
        }
        else if (employee is not null)
        {
            _userType = 3;
            user.Employee = employee;
        }
        else if (patient is not null)
        {
            _userType = 4;
            user.Patient = patient;
        }
        else
        {
            _userType = 0;
        }

        var userResponse = new UserResponse
        {
            Id = user.Id,
            IdentityNumber = user.IdentityNumber,
            FullName = user.FirstName + user.LastName,
            DateOfBirth = user.DateOfBirth,
            BloodType = user.BloodType,
            City = user.City,
            Town = user.Town,
            FullAddress = user.FullAddress,
            UserType = _userType,
            Doctor = doctor,
            Nurse = nurse,
            Employee = employee,
            Patient = patient,
            Image = user.Image
        };

        return userResponse;
    }
}
