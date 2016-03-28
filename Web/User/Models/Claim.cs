namespace TuRM.User.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AspNetUserClaims")]
    public partial class Claim
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual User User { get; set; }
    }
}
