using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RIIMS.Application.Services;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Domain.Interfaces;
using RIIMSAPI.Infrastructure;
using RIIMS.Infrastructure.Repositories;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add services to the DI container

builder.Services.AddDbContext<RiimsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RiimsConnectionString"),
        sqlOptions => sqlOptions.MigrationsAssembly("RIIMSAPI") // Specify the migrations assembly here
    ));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Application Services
builder.Services.AddScoped<IAftesiaService, AftesiaService>();
builder.Services.AddScoped<IInstitucioniService, InstitucioniService>();
builder.Services.AddScoped<IPunaVullnetareService, PunaVullnetareService>();
builder.Services.AddScoped<ISpecializimiService, SpecializimetService>();
builder.Services.AddScoped<INiveliAkademikService, NiveliAkademikService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentiService, DepartmentiService>();
builder.Services.AddScoped<IPublikimiService, PublikimiService>();
builder.Services.AddScoped<ILicensaService,LicensaService>();
builder.Services.AddScoped<IProjektiService, ProjektiService>();
builder.Services.AddScoped<IMbikqyresITemaveService, MbikqyresITemaveService>();
builder.Services.AddScoped<INiveliGjuhesorService, NiveliGjuhesorService>();
builder.Services.AddScoped<IGjuhetService, GjuhetService>();
builder.Services.AddScoped<IUserGjuhetService, UserGjuhetService>();

// Infrastructure Repositories
builder.Services.AddScoped<IAftesiaRepository, AftesiaRepository>();
builder.Services.AddScoped<IInstitucioniRepository, InstitucioniRepository>();
builder.Services.AddScoped<IPunaVullnetareRepository, PunaVullnetareRepository>();
builder.Services.AddScoped<ISpecializimetRepository, SpecializimetRepository>();
builder.Services.AddScoped<INiveliAkademikRepository, NiveliAkademikRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartmentiRepository, DepartmeniRepository>();
builder.Services.AddScoped<IPublikimiRepository, PublikimiRepository>();
builder.Services.AddScoped<ILicensaRepository,LicensaRepository>();
builder.Services.AddScoped<IProjektiRepository, ProjektiRepository>();
builder.Services.AddScoped<IMbikqyresITemaveRepository, MbikqyresITemaveRepository>();
builder.Services.AddScoped<INiveliGjuhesorRepository, NiveliGjuhesorRepository>();
builder.Services.AddScoped<IGjuhetRepository, GjuhetRepository>();
builder.Services.AddScoped<IUserGjuhetRepository, UserGjuhetRepository>();




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
