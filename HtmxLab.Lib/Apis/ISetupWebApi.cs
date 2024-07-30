using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HtmxLab.Lib.Apis;

public interface ISetupWebApi
{
    Task SetupAsync(WebApplication app);
}

public static class WebApiSetup
{
    public static async Task RegisterWebApisAsync(this WebApplication app)
    {
        var apis = app.Services.GetRequiredService<IEnumerable<ISetupWebApi>>();
        foreach (var api in apis)
            await api.SetupAsync(app);
    }
}
