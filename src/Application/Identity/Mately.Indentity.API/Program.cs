using Mately.Common.Constants;
using Mately.Indentity.API.Helpers.Security;
using Mately.Indentity.API.Helpers.ServiceRegistration;
using Mately.Indentity.API.Infrastructure;
using Mately.Indentity.API.Repository.Account;
using Mately.Indentity.API.Repository.AccountSecuriy;
using Mately.Indentity.API.Repository.Base;
using Mately.Indentity.API.Repository.Device;
using Mately.Indentity.API.Repository.User;
using Mately.Indentity.API.Services.Account;
using Mately.Indentity.API.Services.AccountSecurity;
using Mately.Indentity.API.Services.Auth;
using Mately.Indentity.API.Services.Device;
using Mately.Indentity.API.Services.User;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDataProtection();

builder.Services.AddScoped<ISecurityHelper, SecurityHelper>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IDeviceRepository,DeviceRepository>();
builder.Services.AddScoped<IAccountSecurityRepository,AccountSecurityRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));

builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IAccountSecurityService,AccountSecurityService>();
builder.Services.AddScoped<IDeviceService,DeviceService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.Add(ServiceRegistration.ServiceRegistration());

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