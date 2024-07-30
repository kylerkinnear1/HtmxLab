using HtmxLab.Lib.Apis;
using Microsoft.AspNetCore.Mvc;

namespace HtmxLab.Components.Pilot;

public class Api(ILiquidRenderer liquidRenderer) : ISetupWebApi
{
    public Task SetupAsync(WebApplication app)
    {
        app.MapGet("/pilots/{pilotSlug}", async ([FromRoute] string pilotSlug) =>
        {
            var pilot = PilotCards.All.SingleOrDefault(x => x.Slug.Equals(pilotSlug, StringComparison.InvariantCultureIgnoreCase));
            return await liquidRenderer.RenderAsync("Components.Pilot.pilot.liquid", PilotCards.XWing.LukeSkywalker);
        });
        
        return Task.CompletedTask;
    }
}