using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Infrastructure.Persistence.Configurations;
using AIDreamDecoder.Infrastructure.Services;
using AIDreamDecoder.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT Configuration
var jwtConfig = new AuthenticationConfig
{
    SecretKey = "YourSuperSecretKey",
    Issuer = "Issuer",
    Audience = "Audience"
};
builder.Services.AddSingleton(jwtConfig);

// Register TokenService
builder.Services.AddScoped<ITokenService>(provider =>
    new TokenService(jwtConfig.SecretKey, jwtConfig.Issuer, jwtConfig.Audience));

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

// Register AI service
//builder.Services.AddScoped<IAIDreamInterpreterService, OpenAIDreamInterpreterService>(); 

var app = builder.Build();

// Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
