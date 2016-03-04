using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;

namespace TuRM.Portrait.ViewModels.Product
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Preis")]
        public float Price { get; set; }

        public int ProductCategoryId { get; set; }
        
        public WebImage Image { get; set; }

        [Required]
        [Display(Name = "Anzeige-Breite")]
        public short? DisplayWidth { get; set; }

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
