namespace TuRM.User.Models
{
    using System.Data.Entity;

    public partial class UserStoreDbContext : DbContext
    {
        public UserStoreDbContext()
            : base("name=UserStoreConnection")
        {
        }

        public virtual DbSet<Role> AspNetRoles { get; set; }
        public virtual DbSet<Claim> AspNetUserClaims { get; set; }
        public virtual DbSet<Login> AspNetUserLogins { get; set; }
        public virtual DbSet<User> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Claims)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Logins)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
