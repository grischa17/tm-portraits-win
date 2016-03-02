using Microsoft.AspNet.Identity.EntityFramework;

namespace TuRM.Portrait.Models
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext()
            : base("DefaultConnection")
        {
        }


        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }
    }
}
