using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TuRM.Portrait.Models
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext()
            : base("UserStoreConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationIdentityDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }
    }
}
