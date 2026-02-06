using System.Text;
using Backend.Data;
using Backend.Service;
using Backend.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
// DI
builder.Services.AddScoped<IAuthService, AuthService>();

// Database connection
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
));

// JWT auth
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!)),
      ValidateIssuer = true,
      ValidIssuer = jwtIssuer,
      ValidateAudience = true,
      ValidAudience = jwtAudience,
      ValidateLifetime = true
    };
  });

builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", policy =>
  {
    policy.AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin();
      // .AllowCredentials();
  });
});

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- App ---
var app = builder.Build();

// Middleware 
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Map controllers
app.MapControllers();

app.MapGet("/", () => Results.Json(new { id = 1, price = 20000, name = "cam than" }));

app.Run();
