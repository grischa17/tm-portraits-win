namespace TuRM.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AspNetUsers")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Claims = new HashSet<Claim>();
            Logins = new HashSet<Login>();
            Roles = new HashSet<Role>();
        }

        [Display(Name = "#")]
        public string Id { get; set; }

        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Ist Email Bestätigt")]
        public bool EmailConfirmed { get; set; }
        
        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [Display(Name = "Telefonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ist Telefonnumer bestätigt")]
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
        
        [Display(Name = "Ist gesperrt bis")]
        public DateTime? LockoutEndDateUtc { get; private set; }

        [Display(Name = "Ist gesperrt")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Anzahl fehlgeschlagener Anmeldungen")]
        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Claim> Claims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Login> Logins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
