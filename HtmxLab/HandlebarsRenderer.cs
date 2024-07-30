using HandlebarsDotNet;

namespace HtmxLab;

public record TemplateConfig(Dictionary<string, string> Templates);
public class HandlebarsRenderer(TemplateConfig config, ILogger<HandlebarsRenderer> logger) : IRenderer
{
    public string Render(string templateName)
    {
        var templateText = config.Templates[templateName];
        var template = Handlebars.Compile(templateText);
        var html = template(new{});
        logger.LogInformation("Rendered: {HTML}", html);
        return html;
    }

    public string Render<T>(string templateName, T model)
    {
        var templateText = config.Templates[templateName];
        var template = Handlebars.Compile(templateText);
        var html = template(model);
        logger.LogInformation("Rendered: {HTML}", html);
        return html;
    }
}

public interface IRenderer
{
    string Render(string templateName);
    string Render<T>(string templateName, T model);
}