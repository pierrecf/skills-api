using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using skills_api.Models;
using skills_api.Repositories;
using skills_api.Repositories.Interfaces;
using skills_api.Services;
using skills_api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Mapster configuration, this scans all custom configs
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();


builder.Services.AddScoped<ISkillRepository, SkillRepository>()
    .AddScoped<IGoalRepository,GoalRepository>()
    .AddScoped<IUserRepository,UserRepository>();
builder.Services
    .AddScoped<ISkillService, SkillService>()
    .AddScoped<IGoalService, GoalService>()
    .AddScoped<IUserService, UserService>()
    .AddSingleton(config)
    .AddScoped<IMapper, ServiceMapper>();


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

Seeder.SeedDatabase(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();



app.Run();


