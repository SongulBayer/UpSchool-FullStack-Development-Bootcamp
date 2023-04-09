using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Contexts
{
    public class IdentityContext:IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Ignore
            //Verilen ada sahip bir varlık türünü modelden dışlar. Bu yöntem genellikle
            modelBuilder.Ignore<Account>();
            modelBuilder.Ignore<Country>();
            modelBuilder.Ignore<City>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
