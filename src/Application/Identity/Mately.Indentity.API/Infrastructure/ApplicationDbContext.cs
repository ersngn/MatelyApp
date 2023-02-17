using Mately.Indentity.API.Domain.Account;
using Mately.Indentity.API.Domain.Device;
using Mately.Indentity.API.Domain.Security;
using Mately.Indentity.API.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Mately.Indentity.API.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AccountSecurity> AccountSecurities { get; set; }
}