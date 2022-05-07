using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using n5now.Data;
using n5now.Persistences;
using n5now.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

DbCreated.CreateDbIfNotExists(app);
app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
    services.AddSingleton<IESClientProvider, ESClientProvider>();
    services.AddControllers();
    services.AddDbContext<ContextDatabase>(
        options => options.UseSqlServer("name=ConnectionStrings:cn"));

    services.AddScoped<IPermissionsService, PermissionsService>();
}
