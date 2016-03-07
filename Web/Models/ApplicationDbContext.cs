namespace TuRM.Portrait.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationIdentityDbContext>());
        }

        public virtual DbSet<BillCancellation> BillCancellations { get; set; }
        public virtual DbSet<BillHead> BillHeads { get; set; }
        public virtual DbSet<BillItem> BillItems { get; set; }
        public virtual DbSet<PriceAdjustment> PriceAdjustments { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RequestCancellation> RequestCancellations { get; set; }
        public virtual DbSet<RequestHead> RequestHeads { get; set; }
        public virtual DbSet<RequestImage> RequestImages { get; set; }
        public virtual DbSet<RequestItem> RequestItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillHead>()
                .HasOptional(e => e.BillCancellation)
                .WithRequired(e => e.BillHead);

            modelBuilder.Entity<BillHead>()
                .HasMany(e => e.BillItems)
                .WithRequired(e => e.BillHead)
                .HasForeignKey(e => e.HeadId);

            modelBuilder.Entity<PriceAdjustment>()
                .HasMany(e => e.Products)
                .WithMany(e => e.PriceAdjustments)
                .Map(m => m.ToTable("PriceAdjustmentProducts"));
        }
    }
}
