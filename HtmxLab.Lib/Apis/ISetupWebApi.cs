using Microsoft.AspNetCore.Builder;

namespace HtmxLab.Lib.Apis;

public interface ISetupWebApi
{
    Task SetupAsync(WebApplication app);
}
