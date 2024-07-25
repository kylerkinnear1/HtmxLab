using HtmxLab;
using HtmxLab.Lib.Apis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
foreach (var api in app.Services.GetRequiredService<IEnumerable<ISetupWebApi>>())
    await api.SetupAsync(app);

app.Run();
