using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Infrastructure.Persistence.Configurations;
using AIDreamDecoder.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);





// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Issuer",
            ValidAudience = "Audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey"))
        };
    });

/*builder.Services.AddJwtAuthentication(builder.Configuration);

// Register services
builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDreamService, DreamService>();*/

// Add authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
