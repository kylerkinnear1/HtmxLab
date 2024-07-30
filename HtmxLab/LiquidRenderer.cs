using Fluid;

namespace HtmxLab;

public interface ILiquidRenderer
{
    Task<string> RenderAsync(string templateName);
    Task<string> RenderAsync<T>(string templateName, T model, Action<TemplateOptions>? options = null);
}

public class LiquidTemplateLoader
{
    public const string TemplatePath = "./templates/";
    
    public static TemplateConfig ScanDirectory(string templatePath)
    {
        var templates = new Dictionary<string, string>();
        foreach (var file in Directory.GetFiles(templatePath, "*.liquid"))
        {
            var templateName = Path.GetFileNameWithoutExtension(file);
            var content = File.ReadAllText(file);
            templates[templateName.ToLower()] = content;
        }

        return new(templates);
    }
}

public class LiquidRenderer(FluidParser parser, ILogger<LiquidRenderer> logger, TemplateConfig templates) : ILiquidRenderer
{
    public async Task<string> RenderAsync(string templateName)
    {
        var rendered = parser.TryParse(templates.Templates[templateName.ToLower()], out var template, out var error)
            ? await template.RenderAsync()
            : error;

        logger.LogInformation(rendered);
        return rendered;
    }

    public async Task<string> RenderAsync<T>(string templateName, T model, Action<TemplateOptions>? options = null)
    {
        var optionInput = options != null ? new TemplateOptions() : null;
        options?.Invoke(optionInput!);
        var rendered = parser.TryParse(templates.Templates[templateName.ToLower()], out var template, out var error)
            ? await template.RenderAsync(optionInput != null ? new(model, optionInput) : new(model))
            : error;

        logger.LogInformation(rendered);
        return rendered;
    }
}
