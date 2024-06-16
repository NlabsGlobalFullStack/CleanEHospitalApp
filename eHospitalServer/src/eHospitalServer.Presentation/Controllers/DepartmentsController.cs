﻿using eHospitalServer.Application.Features.Departments.CreateDepartment;
using eHospitalServer.Application.Features.Departments.DeleteByIdDepartment;
using eHospitalServer.Application.Features.Departments.GetAllDepartments;
using eHospitalServer.Application.Features.Departments.GetByIdDepartment;
using eHospitalServer.Application.Features.Departments.UpdateDepartment;
using eHospitalServer.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHospitalServer.Presentation.Controllers;


[AllowAnonymous]
public sealed class DepartmentsController : ApiController
{
    public DepartmentsController(IMediator mediator) : base(mediator) {}

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDepartmentsQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetByIdDepartmentCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteByIdDepartmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
