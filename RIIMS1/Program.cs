using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RIIMS.Application.Services;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Domain.Interfaces;
using RIIMS.Infrastructure.Repositories;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using RIIMS.Infrastructure.Data;
using RIIMS.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        builder.WithOrigins("http://localhost:3000") 
               .AllowAnyMethod()  
               .AllowAnyHeader()  
               .AllowCredentials();  
    });
});

builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<RiimsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RiimsConnectionString"),
        sqlOptions => sqlOptions.MigrationsAssembly("RIIMS.Infrastructure") // Specify the migrations assembly here
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
builder.Services.AddScoped<IEdukimiService, EdukimiService>();
builder.Services.AddScoped<IEksperiencaService, EksperiencaService>();
builder.Services.AddScoped<IHonorsAndAwardsService, HonorsAndAwardsService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IImageService, ImageService>();

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
builder.Services.AddScoped<IEdukimiRepository, EdukimiRepository>();
builder.Services.AddScoped<IEksperiencaRepository, EksperiencaRepository>();
builder.Services.AddScoped<IHonorsAndAwardsRepository, HonorsAndAwardsRepository>();
builder.Services.AddScoped<IUserGjuhetRepository, UserGjuhetRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

//Infrastructure Services
builder.Services.AddScoped<IFileStorageService, FileStorageService>();


builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>("Riims")
    .AddEntityFrameworkStores<RiimsDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });


// Add controllers and API-specific configurations
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Riims API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"

});

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
