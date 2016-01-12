using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class RequestHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [InverseProperty(nameof(RequestImage.RequestHead))]
        public List<RequestImage> Images { get; set; }

        [InverseProperty(nameof(RequestItem.RequestHead))]
        public List<RequestItem> Items { get; set; }

        [InverseProperty(nameof(BillHead.RequestHead))]
        public List<BillHead> BillHeads { get; set; }
    }
}