using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TM.Abstractions;
using TM.Application.Interfaces;
using TM.Application.Interfaces.Infrastructure;
using TM.Application.Middlewares;
using TM.Application.Services;
using TM.Infrastructure;
using TM.Persistance;
using TM.Repositories;
using TM.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
AddServices(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "TM.WebApi v1"));
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

void AddServices(IServiceCollection builderServices)
{
    builder.Services.AddOpenApi();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services
        .AddDbContext<ApplicationDbContext>(optionsBuilder => { optionsBuilder.UseSqlite(connectionString); })
        .AddSwaggerGen()
        .AddEndpointsApiExplorer()
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<ITaskRepository, TaskRepository>()
        .AddScoped<IPasswordHasher, PasswordHasher>()
        .AddScoped<IUserService, UserService>()
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
        .AddFluentValidationAutoValidation()
        .AddControllers();
}