using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Domain.User.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mately.Identity.API.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
    {  
        
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationUserDevice> ApplicationUserDevices { get; set; }
    public DbSet<ApplicationUserSecurityKey> ApplicationUserSecurityKeys { get; set; }

}