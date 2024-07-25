using HtmxLab.Lib.Apis;

namespace HtmxLab.Apis;

public class TestApi : ISetupWebApi
{
    public Task SetupAsync(WebApplication app)
    {
        app.MapGet("test", async () => "testing")
            .WithName("test")
            .WithOpenApi();

        return Task.CompletedTask;
    }
}
