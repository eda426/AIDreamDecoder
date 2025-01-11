using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Infrastructure.Persistence.Configurations;
using AIDreamDecoder.Infrastructure.Persistence.Context;
using AIDreamDecoder.Infrastructure.Repositories;
using AIDreamDecoder.Infrastructure.Services;
using AIDreamDecoder.Infrastructure.Settings;
using AIDreamDecoder.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenAI.Extensions;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// JWT Configuration
var jwtConfig = new AuthenticationConfig
{
    SecretKey = "N3Xx68uXqIwpQrtyL3vd8XwzK89ql5+Gpd1u2gRFBjk=",
    Issuer = "AIDreamDecoder",
    Audience = "AIDreamDecoder"
};
builder.Services.AddSingleton(jwtConfig);

// Register TokenService
builder.Services.AddScoped<IJwtService>(provider =>
    new JwtService(jwtConfig.SecretKey, jwtConfig.Issuer, jwtConfig.Audience));

// Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
        };
    });


builder.Services.AddAuthorization();

// Add OpenAI settings
builder.Services.Configure<OpenAISettings>(
    builder.Configuration.GetSection("OpenAI"));


builder.Services.AddOpenAIService(settings =>
{
    settings.ApiKey = builder.Configuration["OpenAI:ApiKey"];
});


builder.Services.AddDbContext<AIDreamDecoderDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register our services
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddScoped<IAIDreamInterpreterService, OpenAIDreamInterpreterService>();
builder.Services.AddSingleton<IRootPathService>(new RootPathManager(builder.Environment.WebRootPath));
builder.Services.AddScoped<IDreamService, DreamService>();
builder.Services.AddScoped<IDreamRepository, DreamRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();



builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static object GetUseNpgsql(DbContextOptionsBuilder options)
{
    return options.UseNpgsql();
}