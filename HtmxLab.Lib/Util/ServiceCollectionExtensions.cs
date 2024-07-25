using Microsoft.Extensions.DependencyInjection;

namespace HtmxLab.Lib.Util;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterAll<TInterface>(this IServiceCollection services, Type assembly) =>
        services.RegisterAll(typeof(TInterface), assembly);

    public static IServiceCollection RegisterAll(this IServiceCollection services, Type interfaceType, Type assemblyType)
    {
        var implementations = assemblyType.Assembly
            .GetTypes()
            .Where(x => interfaceType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

        foreach (var i in implementations)
            services.AddSingleton(interfaceType, i);

        return services;
    }
}
