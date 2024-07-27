using Fluid;
using HtmxLab;
using HtmxLab.Lib.Apis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
foreach (var api in app.Services.GetRequiredService<IEnumerable<ISetupWebApi>>())
    await api.SetupAsync(app);

app.UseStaticFiles();
app.UseDefaultFiles("/index.html");
app.MapGet("update-content", async () =>
{
    var options = new TemplateOptions();
    options.MemberAccessStrategy.Register<Child>();
    var model = new Parent([new("Billy", "Bob"), new("Sally", "Bob")]);
    return await Renderer.RenderAsync("Templates.main.liquid", model, options);
});

await app.RunAsync();

public record Parent(List<Child> Children);
public record Child(string FirstName, string LastName);