namespace TuRM.Portrait.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillHead()
        {
            BillItems = new HashSet<BillItem>();
        }

        public int Id { get; set; }

        public int RequestHeadId { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        [StringLength(64)]
        public string StreetPostOfficeBox { get; set; }

        [StringLength(8)]
        public string HouseNumber { get; set; }

        [Required]
        [StringLength(16)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(64)]
        public string City { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(256)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public virtual BillCancellation BillCancellation { get; set; }

        public virtual RequestHead RequestHead { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
