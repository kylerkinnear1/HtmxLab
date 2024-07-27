using Fluid;
using HtmxLab;
using HtmxLab.Lib.Apis;
using HtmxLab.Templates;

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
app.MapGet("update-content", async () => await Renderer.RenderAsync(
    "Templates.Main.liquid", 
    new Parent([new("Billy", "Bob"), new("Sally", "Bob")]), 
    opt => opt.MemberAccessStrategy.Register<Child>()));

await app.RunAsync();