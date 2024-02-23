using Microsoft.OpenApi.Models;
using RainfallAPI.Application.Queries.GetRainfallReadingQuery;
using System.Reflection;

const string swaggerVersion = "1.0";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(swaggerVersion, new OpenApiInfo
    {
        Version = swaggerVersion,
        Title = "Rainfall Api",
        Description = "An API which provides rainfall reading data",
        Contact = new OpenApiContact
        {
            Name = "Sorted",
            Url = new Uri($"https://www.sorted.com")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.EnableAnnotations();
});

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(GetRainfallReadingQueryHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint($"{swaggerVersion}/swagger.json", "Rainfall Api");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
