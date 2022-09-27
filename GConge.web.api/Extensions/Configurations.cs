using System.Reflection;
using System.Text;
using GConge.Models.Models.Identity;
using GConge.Models.Utils;
using GConge.web.api.Data;
using GConge.web.api.Models.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GConge.web.api.Extensions;

static public class Configurations
{
  static public IServiceCollection AddMySqlContext(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = configuration.GetConnectionString("MyDbConnection");
    var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
    services.AddDbContext<GCongeDbContext>(options =>
      options.UseMySql(connectionString, serverVersion)
        // .LogTo(Console.WriteLine, LogLevel.Information)
        // .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );

    return services;
  }

  static public IServiceCollection AddJwtService(this IServiceCollection services, IConfiguration configuration)
  {
    bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    var jwtSettings = Utils.GetConfig<JwtSettings>(isDevelopment);
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
          };
        }
      );

    return services;
  }
  static public void AddCorsService(this IServiceCollection services)
  {
    bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    var serverSettings = Utils.GetConfig<ServerSettings>(isDevelopment);

    services.AddCors(options =>
      {
        options.AddPolicy(
          serverSettings.CorsPolicyName,
          policy =>
          {
            policy
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins(serverSettings.AllowedOrigins);
          }
        );
      }
    );
  }

  static public void AddSwaggerService(this IServiceCollection services)
  {
    bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    var serverDoc = Utils.GetConfig<ServerDocSettings>(isDevelopment);
    services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc(
          serverDoc.Version,
          info: new OpenApiInfo
          {
            Title = serverDoc.Title,
            Version = serverDoc.Version,
            Description = serverDoc.Description,
            Contact = new OpenApiContact
            {
              Name = serverDoc.Contact.Name,
              Email = serverDoc.Contact.Email,
              Url = new Uri(serverDoc.Contact.Url)
            },
            License = new OpenApiLicense
            {
              Name = serverDoc.License.Name,
              Url = new Uri(serverDoc.License.Url)
            }
          }
        );

        var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
      }
    );
  }
}
