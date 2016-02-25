using LetPaintPictures.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LetPaintPictures.ViewModels.Request
{
    public class Create
    {
        [UIHint("Product")]
        [Display(Name = "Portrait-Typ:")]
        public int ProductId { get; set; }

        public IQueryable<Product> Products { get; set; } = new List<Product>().AsQueryable();

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

        public IQueryable<Product> Sizes { get; set; } = new List<Product>().AsQueryable();

        [Required]
        [Display(Name = "Vorname:")]
        public string FirstName { get; set; }

        [Display(Name = "Nachname:")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Strasse/Postfach, Hausnummer:")]
        public string StreetPostOfficeBox { get; set; }

        public string HouseNumber { get; set; }

        [Display(Name = "Postleitzahl, Ort:")]
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(128)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Bemerkung:")]
        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Bilder hochladen")]
        public SortedList<string, WebImage> Files { get; set; } = new SortedList<string, WebImage>();

        public float TotalAmount { get; set; }

        public Product SubjectProduct { get; set; }

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