using System.Reflection;
using HtmxLab.Lib.Apis;
using HtmxLab.Lib.Util;

namespace HtmxLab.Apis;

public class TestApi : ISetupWebApi
{
    public Task SetupAsync(WebApplication app)
    {
        app.MapGet("update-content", async () => await "Templates.main.liquid".LoadStringFileAsync(Assembly.GetExecutingAssembly()));
        return Task.CompletedTask;
    }
}
