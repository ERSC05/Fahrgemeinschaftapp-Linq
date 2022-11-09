using Carpool_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using TecAlliance.Carpool.Bussines;
using TecAlliance.Carpool.Bussines.Models;
using TecAlliance.Carpool.Bussines.Services;
using TecAlliance.Carpool.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Carpool API",
        Description = "An ASP.NET Core Web API for an carpool",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.ExampleFilters();

});
builder.Services.AddSingleton<DriverDtoDtoProvider>();
builder.Services.AddSingleton<CarpoolDtoProvider>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CarpoolDtoProvider>();

builder.Services.AddScoped<ICarpoolBussinesService, CarpoolBussinesService>();
builder.Services.AddScoped<ICarpoolDataService, CarpoolDataService>();

builder.Services. AddSingleton<IDriverBussinesService, DriverBussinesService>();
builder.Services.AddTransient<IDriverDataService, DriverDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "driverApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();