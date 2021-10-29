using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; 
  
namespace Travel.Models  
{  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {  
          
        }  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);
            base.OnModelCreating(builder);
        builder.Ignore <IdentityUserLogin<string>>();
        builder.Ignore <IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUser<string>>();
        builder.Ignore<ApplicationUser>();   
        }  
    }  
}  