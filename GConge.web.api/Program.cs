using GConge.Models.Utils;
using GConge.web.api.Extensions;
using GConge.web.api.Models.Configs;
using GConge.web.api.Repositories;
using GConge.web.api.Repositories.Contracts;
using GConge.web.api.Services;
using GConge.web.api.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();
builder.Services.AddMySqlContext(builder.Configuration);
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddCorsService();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();

var app = builder.Build();

bool isDevelopment = builder.Environment.IsDevelopment();
var serverDoc = Utils.GetConfig<ServerDocSettings>(isDevelopment);
var serverSettings = Utils.GetConfig<ServerSettings>(isDevelopment);

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(
  options =>
  {
    options.DocumentTitle = serverDoc.Title;
    options.SwaggerEndpoint(url: $"/swagger/{serverDoc.Version}/swagger.json", serverDoc.Title);
    options.RoutePrefix = string.Empty;
  }
);

app.UseCors(serverSettings.CorsPolicyName);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
