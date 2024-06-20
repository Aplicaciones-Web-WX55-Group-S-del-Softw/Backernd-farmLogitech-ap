using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Ratings.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Subscriptions.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //BORRAR TODAS LAS TABLAS ANTES DE CREAR NUEVAS, PARA QUE SE ACTUALICE
            // Configuración de la entidad Farm
            builder.Entity<Farm>().ToTable("Farms");
            builder.Entity<Farm>().HasKey(f => f.Id);
            builder.Entity<Farm>().Property(f => f.Location);
            builder.Entity<Farm>().Property(f => f.Type);
            builder.Entity<Farm>().Property(f => f.Infrastructure);
            builder.Entity<Farm>().Property(f => f.Certificate);
            builder.Entity<Farm>().Property(f => f.Product);
            builder.UseSnakeCaseNamingConvention();

            // Configuración de la entidad Shed
            builder.Entity<Shed>().ToTable("Sheds");
            builder.Entity<Shed>().HasKey(f => f.Id);
            builder.Entity<Shed>().Property(f => f.FarmId);
            builder.Entity<Shed>().Property(f => f.Location);
            builder.Entity<Shed>().Property(f => f.Type);
            
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad Animal
            builder.Entity<Animal>().ToTable("Animals");
            builder.Entity<Animal>().HasKey(f => f.Id);
            builder.Entity<Animal>().Property(f => f.Age);
            builder.Entity<Animal>().Property(f => f.Location);
            builder.Entity<Animal>().Property(f => f.HealthState);
            builder.Entity<Animal>().Property(f => f.ShedId);
            builder.Entity<Animal>().Property(f => f.FarmId);
            builder.Entity<Animal>().Property(f => f.UserId);
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad Crop
            builder.Entity<Crop>().ToTable("Crops");
            builder.Entity<Crop>().HasKey(f => f.Id);
            builder.Entity<Crop>().Property(f => f.Type);
            builder.Entity<Crop>().Property(f => f.PlantingDate);
            builder.Entity<Crop>().Property(f => f.Quantity);
            builder.Entity<Crop>().Property(f => f.ShedId);
            builder.Entity<Crop>().Property(f => f.FarmId);
            builder.Entity<Crop>().Property(f => f.UserId);
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad Rating
            builder.Entity<Rating>().ToTable("Ratings");
            builder.Entity<Rating>().HasKey(f => f.Id);
            builder.Entity<Rating>().Property(f => f.StarRating);
            builder.Entity<Rating>().Property(f => f.UserId);
            builder.UseSnakeCaseNamingConvention();
            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(f => f.Id);
            builder.Entity<Subscription>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(f => f.Description);
            builder.Entity<Subscription>().Property(f => f.Paid);
            builder.Entity<Subscription>().Property(f => f.Price);
            builder.Entity<Subscription>().Property(f => f.ProfileId);
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad Income
            builder.Entity<Income>().ToTable("Incomes");
            builder.Entity<Income>().HasKey(f => f.Id);
            builder.Entity<Income>().Property(f => f.Category);
            builder.Entity<Income>().Property(f => f.Amount);
            builder.Entity<Income>().Property(f => f.Description);
            builder.Entity<Income>().Property(f => f.Date);
            builder.Entity<Income>().Property(f => f.Period);
            builder.Entity<Income>().Property(f => f.FarmId);
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad Expense
            builder.Entity<Expense>().ToTable("Expenses");
            builder.Entity<Expense>().HasKey(f => f.Id);
            builder.Entity<Expense>().Property(f => f.Category);
            builder.Entity<Expense>().Property(f => f.Amount);
            builder.Entity<Expense>().Property(f => f.Description);
            builder.Entity<Expense>().Property(f => f.Date);
            builder.Entity<Expense>().Property(f => f.Period);
            builder.Entity<Expense>().Property(f => f.FarmId);
            builder.UseSnakeCaseNamingConvention();
            
            // Configuration of the Task entity
            builder.Entity<Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task>().ToTable("Tasks");
            builder.Entity<Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task>().HasKey(f => f.Id);
            builder.Entity<Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task>().Property(f => f.CollaboratorId);
            builder.Entity<Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task>().Property(f => f.FarmerId);
            builder.Entity<Backend_farmlogitech.Monitoring.Domain.Model.Aggregates.Task>().Property(f => f.Description);
            builder.UseSnakeCaseNamingConvention();
            
            // Configuration of the Message entity
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(f => f.Id);
            builder.Entity<Message>().Property(f => f.CollaboratorId);
            builder.Entity<Message>().Property(f => f.Description);
            builder.UseSnakeCaseNamingConvention();
            
            //Configuracion de la entidad profile
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.id);
            builder.Entity<Profile>().Property(p => p.name);
            builder.Entity<Profile>().Property(p => p.email);
            builder.Entity<Profile>().Property(p => p.direction);
            builder.Entity<Profile>().Property(p => p.documentNumber);
            builder.Entity<Profile>().Property(p => p.documentType);
            builder.Entity<Profile>().Property(p => p.userId);
            builder.UseSnakeCaseNamingConvention();
            
            
            // Configuración de la entidad User
            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(e => e.Id);
            builder.Entity<Employee>().Property(e => e.FarmId);
            builder.Entity<Employee>().Property(e => e.Name);
            builder.Entity<Employee>().Property(e => e.Phone);
            builder.Entity<Employee>().Property(e => e.Username);
            builder.Entity<Employee>().Property(e => e.Password);
            builder.Entity<Employee>().Property(e => e.Position);
            builder.UseSnakeCaseNamingConvention();
            
            // IAM Context
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            builder.UseSnakeCaseNamingConvention();
        }
    }
}