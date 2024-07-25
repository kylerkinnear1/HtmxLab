using HtmxLab.Lib.Apis;
using HtmxLab.Lib.Util;

namespace HtmxLab;

public static class Setup
{
    public static void AddSetup(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.RegisterAll<ISetupWebApi>(typeof(Setup));
    }
}
