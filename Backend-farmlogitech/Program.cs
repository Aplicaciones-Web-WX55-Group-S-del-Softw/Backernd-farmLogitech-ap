using backend_famLogitech_aw.Shared.Domain.Repositories;
using backend_famLogitech_aw.Shared.Infrastructure.Interfaces.ASP.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Application.Internal.CommandServices;
using Backend_farmlogitech.DashboardAnalytics.Application.Internal.QueryServices;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.DashboardAnalytics.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Farms.Application.Internal.CommandServices;
using Backend_farmlogitech.Farms.Application.Internal.QueryServices;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.Farms.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.IAM.Application.Internal.CommandServices;
using Backend_farmlogitech.IAM.Application.Internal.OutboundServices;
using Backend_farmlogitech.IAM.Application.Internal.QueryServices;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Services;
using Backend_farmlogitech.IAM.Infrastructure.Hashing.BCrypt.Services;
using Backend_farmlogitech.IAM.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Backend_farmlogitech.IAM.Infrastructure.Tokens.JWT.Configuration;
using Backend_farmlogitech.IAM.Infrastructure.Tokens.JWT.Services;
using Backend_farmlogitech.IAM.Interfaces.ACL;
using Backend_farmlogitech.IAM.Interfaces.ACL.Services;
using Backend_farmlogitech.Monitoring.Application.Internal.Animals.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Animals.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Crops.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Crops.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Messages.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Messages.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Sheds.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Sheds.QueryServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Tasks.CommandServices;
using Backend_farmlogitech.Monitoring.Application.Internal.Tasks.QueryServices;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Tasks;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Crops;
using Backend_farmlogitech.Monitoring.Domain.Services.Messages;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Services.Tasks;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistance.EFC.Repositories.Sheds;
using Backend_farmlogitech.Subscriptions.Application.Internal.CommandServices;
using Backend_farmlogitech.Subscriptions.Application.Internal.QueryServices;
using Backend_farmlogitech.Subscriptions.Domain.Repositories;
using Backend_farmlogitech.Subscriptions.Domain.Services;
using Backend_farmlogitech.Subscriptions.Infrastructure.Persistance.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistence.EFC.Repositories.Messages;
using Backend_farmlogitech.Monitoring.Infrastructure.Persistence.EFC.Repositories.Tasks;
using Backend_farmlogitech.Profiles.Application.Internal.CommandServices;
using Backend_farmlogitech.Profiles.Application.Internal.QueryServices;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Services;
using Backend_farmlogitech.Profiles.Infrastructure.Persistance.EFC.Repositories;
using Backend_farmlogitech.Profiles.Interfaces.ACL;
using Backend_farmlogitech.Profiles.Interfaces.ACL.Services;
using Backend_farmlogitech.Ratings.Application.Internal.CommandServices;
using Backend_farmlogitech.Ratings.Application.Internal.QueryServices;
using Backend_farmlogitech.Ratings.Domain.Repositories;
using Backend_farmlogitech.Ratings.Domain.Services;
using Backend_farmlogitech.Ratings.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "FarmLogiTech",
                Version = "v1",
                Description = "FarmLogiTech Platform API",
                TermsOfService = new Uri("https://farmlogitech.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "FarmLogiTech",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    } 
                }, 
                Array.Empty<string>()
            }
        });
    });
// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

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

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskCommandService, TaskCommandService>();
builder.Services.AddScoped<ITaskQueryService, TaskQueryService>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageCommandService, MessageCommandService>();
builder.Services.AddScoped<IMessageQueryService, MessageQueryService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IIncomeCommandService, IncomeCommandService>();
builder.Services.AddScoped<IIncomeQueryService, IncomeQueryService>();

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseCommandService, ExpenseCommandService>();
builder.Services.AddScoped<IExpenseQueryService, ExpenseQueryService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();

builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingCommandService, RatingCommandService>();
builder.Services.AddScoped<IRatingQueryService, RatingQueryService>();

var app = builder.Build();

// Verify Database Objects are created
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



//app.UseCors("AllowAllPolicy");


// app.UseRequestAuthorization();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();