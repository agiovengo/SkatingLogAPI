using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Services;
using System.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SkatingLogDB")).EnableSensitiveDataLogging().EnableDetailedErrors());
builder.Services.AddScoped<UserService>();

builder.Services.AddHealthChecks().AddDbContextCheck<dBContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://agiovengo.github.io", "http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});

app.Run();
