using LetPaintPictures.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.ViewModels.Bill
{
    public class Head
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestHeadId { get; set; }

        public RequestHead RequestHead { get; set; }

        #region Person
        [Display(Name = "Vorname:")]
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Display(Name = "Nachname:")]
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        #endregion

        #region Address
        [Display(Name = "Straße/Postfach, Hausnr.:")]
        [Required]
        [MaxLength(64)]
        public string StreetPostOfficeBox { get; set; }

        [MaxLength(8)]
        public string HouseNumber { get; set; }

        [Display(Name = "Plz., Ort:")]
        [Required]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }
        #endregion

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        [Display(Name = "Bemerkung:")]
        [DataType(DataType.MultilineText)]
        [MaxLength(256)]
        public string Remarks { get; set; }

        [Display(Name = "Email:")]
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        
        public List<Item> Items { get; set; }
    }
}
