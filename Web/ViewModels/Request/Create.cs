using TuRM.Portrait.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;

namespace TuRM.Portrait.ViewModels.Request
{
    public class Create
    {
        [UIHint("Product")]
        [Display(Name = "Portrait-Typ:")]
        public int ProductId { get; set; }

        public IQueryable<Product.Product> Products { get; set; } = new List<Product.Product>().AsQueryable();

        [UIHint("Slider")]
        [AdditionalMetadata("Min", 1)]
        [AdditionalMetadata("Max", 5)]
        [AdditionalMetadata("Default", 1)]
        [Range(1.0, 5.0)]
        [Display(Name = "Anzahl Personen oder Tiere:")]
        public int CountSubjects { get; set; } = 1;

        [UIHint("SizeSlider")]
        [Display(Name = "Größe:")]
        public int SizeId { get; set; }

        public IQueryable<Product.Product> Sizes { get; set; } = new List<Product.Product>().AsQueryable();

        [Required]
        [Display(Name = "Vorname:")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Display(Name = "Nachname:")]
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Strasse/Postfach, Hausnummer:")]
        [MaxLength(64)]
        public string StreetPostOfficeBox { get; set; }

        [MaxLength(8)]
        public string HouseNumber { get; set; }

        [Display(Name = "Postleitzahl, Ort:")]
        [Required]
        [DataType(DataType.PostalCode)]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(64)]
        public string City { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(256)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Bemerkung:")]
        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Bilder hochladen")]
        public SortedList<string, WebImage> Files { get; set; } = new SortedList<string, WebImage>();

        public float TotalAmount { get; set; }

        public Product.Product SubjectProduct { get; set; }

        public int MaxFileSize
        {
            get
            {
                HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;

                return section.MaxRequestLength;
            }
        }
    }
}