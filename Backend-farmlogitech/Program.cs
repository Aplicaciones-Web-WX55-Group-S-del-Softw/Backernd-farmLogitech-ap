using backend_famLogitech_aw.Shared.Domain.Repositories;
using backend_famLogitech_aw.Shared.Infrastructure.Interfaces.ASP.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Farms.Application.Internal.CommandServices;
using Backend_farmlogitech.Farms.Application.Internal.QueryServices;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.Farms.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Application.Internal.Animals.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Animals.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Crops.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Crops.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Sheds.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Sheds.QueryServices;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Crops;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Sheds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Conventions.Add(new KebabCaseRoutingNamingConvention());   
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");




// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFarmCommandService, FarmCommandService>();
builder.Services.AddScoped<IFarmQueryService, FarmQueryService>();
builder.Services.AddScoped<IShedRepository, ShedRepository>();
builder.Services.AddScoped<IShedCommandService, ShedCommandService>();
builder.Services.AddScoped<IShedQueryService, ShedQueryService>();

builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropCommandService, CropCommandService>();
builder.Services.AddScoped<ICropQueryService, CropQueryService>();

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalCommandService, AnimalCommandService>();
builder.Services.AddScoped<IAnimalQueryService, AnimalQueryService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();