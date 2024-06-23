using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace eHospitalServer.Domain.Repositories.CustomRepositories;
public interface IMyHostEnvironment : IHostEnvironment
{
    string WebRootPath { get; set; }

    IFileProvider WebRootFileProvider { get; set; }
}
