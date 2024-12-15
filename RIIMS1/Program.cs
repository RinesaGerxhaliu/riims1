using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RIIMS.Application.Services;
using RIIMSAPI.Domain.Interfaces;
using RIIMSAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container

builder.Services.AddDbContext<RiimsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RiimsConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Application Services
builder.Services.AddScoped<IAftesiaService, AftesiaService>();
builder.Services.AddScoped<IInstitucioniService, InstitucioniService>();

// Infrastructure Repositories
builder.Services.AddScoped<IAftesiaRepository, AftesiaRepository>();
builder.Services.AddScoped<IInstitucioniRepository, InstitucioniRepository>();


// Add controllers and API-specific configurations
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
