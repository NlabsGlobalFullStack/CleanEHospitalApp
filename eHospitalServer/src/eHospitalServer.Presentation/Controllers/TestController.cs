using eHospitalServer.Presentation.Abstraction;
using MediatR;

namespace eHospitalServer.Presentation.Controllers;
public sealed class TestController : ApiController
{
    public TestController(IMediator mediator) : base(mediator) {}
}
