using HandlebarsDotNet;

namespace HtmxLab;

public static class HandlebarsSetup
{
    public static WebApplicationBuilder AddHandlebars(this WebApplicationBuilder builder)
    {
        var config = LoadTemplates(builder.Environment.WebRootPath);
        builder.Services.AddSingleton(config);
        builder.Services.AddSingleton<IRenderer, HandlebarsRenderer>();
        return builder;
    }
    
    public static TemplateConfig LoadTemplates(string webRoot)
    {
        var templates = new Dictionary<string, string>();
        var templatePath = Path.Combine(webRoot, "views");
        foreach (var file in Directory.GetFiles(templatePath, "*.handlebars"))
        {
            var templateName = Path.GetFileNameWithoutExtension(file);
            var content = File.ReadAllText(file);
            templates[templateName.ToLower()] = content;
        }

        var partialPath = Path.Combine(webRoot, "views", "partials");
        foreach (var file in Directory.GetFiles(partialPath, "*.handlebars"))
        {
            var partialName = Path.GetFileNameWithoutExtension(file);
            var content = File.ReadAllText(file);
            Handlebars.RegisterTemplate(partialName, content);
        }

        return new(templates);
    }
}