using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LetPaintPictures.Models
{
    // Sie können Profildaten für den Benutzer durch Hinzufügen weiterer Eigenschaften zur ApplicationUser-Klasse hinzufügen. Weitere Informationen finden Sie unter "http://go.microsoft.com/fwlink/?LinkID=317594".
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
            return userIdentity;
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public virtual DbSet<Product> Products { get; set; }
    //    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    //    public virtual DbSet<PriceAdjustment> PriceAdjustments { get; set; }

    //    public virtual DbSet<BillHead> BillHeads { get; set; }
    //    public virtual DbSet<BillItem> BillItems { get; set; }
    //    public virtual DbSet<BillCancellation> BillCancellations { get; set; }

    //    public virtual DbSet<RequestHead> RequestHeads { get; set; }
    //    public virtual DbSet<RequestItem> RequestItems { get; set; }
    //    public virtual DbSet<RequestImage> RequestImages { get; set; }
    //    public virtual DbSet<RequestCancellation> RequestCancellations { get; set; }

    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {

    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        //DependentNavigationPropertyConfiguration<Bill.BillItem> config;

    //        base.OnModelCreating(modelBuilder);

    //        //modelBuilder.Entity<Models.RequestHead>().HasMany(m => m.Bills).WithRequired(r => r.Request).HasForeignKey(fk => fk.RequestId);

    //        //config = modelBuilder.Entity<Models.RequestItem>().HasMany(m => m.BillItems).WithRequired(r => r.RequestItem);
    //        //config.HasForeignKey(fk => new { fk.RequestHeaderId, fk.RequestItemId });

    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}