using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStrings = builder.Configuration.GetConnectionString("UserConnection");

builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
