using api.BusinessLogic.Implementations;
using api.BusinessLogic.Interfaces;
using api.Enums;
using api.Models;
using api.Repositories.Implementations;
using api.Repositories.Interfaces;
using api.Utils.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Repository.Implementation;
using Shop_API.Repository.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Dictionary<string, IEnumerable<UserRoleEnum>> policies = new Dictionary<string, IEnumerable<UserRoleEnum>>
{
    { "AdminOnly", new[] { UserRoleEnum.Admin } },
    { "UserRole", new[] { UserRoleEnum.User } },
    { "AllRoles", new[] { UserRoleEnum.Admin, UserRoleEnum.User} }
};


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.Configure<ConfigSettings>(options => builder.Configuration.GetSection("ConfigSettings").Bind(options));
builder.Services.AddAuthorization(options =>
{
    foreach (var definedPolicy in policies)
    {
        options.AddPolicy(definedPolicy.Key, policy => policy.RequireRole(definedPolicy.Value.Select(v => v.ToString())));
    }
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["ConfigSettings:Issuer"],
            ValidAudience = builder.Configuration["ConfigSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ConfigSettings:TokenSecretKey"]))
        };
    });

// BUSINESS LOGIC
builder.Services.AddScoped<IAuthBL, AuthBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IPreOrderBL, PreOrderBL>();
builder.Services.AddScoped<IFavoriteBL, FavoriteBL>();



//REPOSITORY
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPreOrderRepository, PreOrderRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();

//UTILS
builder.Services.AddScoped<PasswordHasher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
