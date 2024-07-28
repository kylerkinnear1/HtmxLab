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
        var rendered = Parser.TryParse(templateText, out var template, out var error)
            ? await template.RenderAsync()
            : error;

        return rendered;
    }

    public static async ValueTask<string> RenderAsync<T>(string templateName, T model, Action<TemplateOptions>? options = null)
    {
        var optionInput = options != null ? new TemplateOptions() : null;
        options?.Invoke(optionInput!);
        var templateText = await templateName.LoadStringFileAsync(Assembly.GetExecutingAssembly());
        var rendered = Parser.TryParse(templateText, out var template, out var error)
            ? await template.RenderAsync(optionInput != null ? new(model, optionInput) : new(model))
            : error;

        return rendered;
    }
}