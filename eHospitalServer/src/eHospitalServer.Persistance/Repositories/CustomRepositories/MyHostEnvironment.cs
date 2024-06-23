using eHospitalServer.Domain.Repositories.CustomRepositories;
using Microsoft.Extensions.FileProviders;

namespace eHospitalServer.Persistance.Repositories.CustomRepositories;
internal sealed class MyHostEnvironment : IMyHostEnvironment
{
    public string WebRootPath { get; set; } = default;

    public IFileProvider WebRootFileProvider { get; set; } = default;

    public string EnvironmentName { get; set; } = default;

    public string ApplicationName { get; set; } = default;

    public string ContentRootPath { get; set; } = default;

    public IFileProvider ContentRootFileProvider { get; set; } = default;
}
