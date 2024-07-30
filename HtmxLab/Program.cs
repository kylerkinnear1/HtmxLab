using Fluid;
using HtmxLab;
using HtmxLab.Lib.Apis;
using HtmxLab.Lib.Util;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterAll<ISetupWebApi>(typeof(ThisAssembly));

var templateConfig = HandlebarsSetup.LoadTemplates(builder.Environment.WebRootPath);
builder.Services.AddSingleton(templateConfig);
builder.Services.AddSingleton<IRenderer, HandlebarsRenderer>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles("/index.html");
await app.RegisterWebApisAsync();
await app.RunAsync();