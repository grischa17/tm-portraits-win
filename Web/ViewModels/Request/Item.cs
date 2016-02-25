using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.ViewModels.Request
{
    public class Item
    {
        [Display(Name = "#")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Anfrage-Kopf-Id")]
        [Required]
        public int HeadId { get; set; }

        [ForeignKey(nameof(HeadId))]
        public Head Head { get; set; }

        //[Required]
        //public int ProductId { get; set; }

        //[ForeignKey(nameof(ProductId))]
        //public Product Product { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [Display(Name = "Menge")]
        public float Amount { get; set; }

        [Display(Name = "Einzelpreis")]
        public float Price { get; set; }

        [Display(Name = "Gesamtpreis")]
        public float Total { get { return Amount * Price; } }
    }
}
