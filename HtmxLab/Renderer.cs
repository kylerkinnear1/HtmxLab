using System.Reflection;
using Fluid;
using HtmxLab.Lib.Util;

namespace HtmxLab;

public static class Renderer
{
    private static readonly FluidParser Parser = new();

    public static async ValueTask<string> RenderAsync(string templateName)
    {
        var templateText = await templateName.LoadStringFileAsync(Assembly.GetExecutingAssembly());
        return Parser.TryParse(templateText, out var template, out var error)
            ? await template.RenderAsync()
            : error;
    }

    public static async ValueTask<string> RenderAsync<T>(string templateName, T model, TemplateOptions? options = null)
    {
        var templateText = await templateName.LoadStringFileAsync(Assembly.GetExecutingAssembly());
        var rendered = Parser.TryParse(templateText, out var template, out var error)
            ? await template.RenderAsync(options != null ? new(model, options) : new(model))
            : error;

        return rendered;
    }
}