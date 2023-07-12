using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UniClass.Services;
using UniClass.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "University API", Description = "Easily manage students", Version = "v1" });
});

builder.Services.AddTransient<IUniversityService, UniversityService>();

//Registering the database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    
var app = builder.Build();

//Conf the HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "University API V1");
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
