using Fluid;
using HtmxLab.Components.Pilot;
using HtmxLab.Lib.Apis;

namespace HtmxLab.Components.Home;

public class Api(ILiquidRenderer liquidRenderer) : ISetupWebApi
{
    public Task SetupAsync(WebApplication app)
    {
        app.MapGet("/home", async () =>
        {
            var homeModel = new HomeDto(PilotCards.All.ToList());
            return await liquidRenderer.RenderAsync("Home", homeModel, o => o.MemberAccessStrategy.Register<PilotDto>());
        });

        return Task.CompletedTask;
    }
}