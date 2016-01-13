using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class BillHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestHeadId { get; set; }
        
        [ForeignKey(nameof(RequestHeadId))]
        public RequestHead RequestHead { get; set; }

        #region Person
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        #endregion

        #region Address
        [Required]
        [MaxLength(64)]
        public string StreetPostOfficeBox { get; set; }

        [MaxLength(8)]
        public string HouseNumber { get; set; }

        [Required]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }
        #endregion

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [MaxLength(256)]
        public string Remarks { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [InverseProperty(nameof(BillItem.Head))]
        public List<BillItem> Items { get; set; }

        [ForeignKey(nameof(Id))]
        public BillCancellation BillCancellation { get; set; }
    }
}
