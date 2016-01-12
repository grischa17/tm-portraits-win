using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.ViewModels.Bill
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int HeadId { get; set; }

        //[ForeignKey(nameof(HeadId))]
        //public Head Head { get; set; }

        [Display(Name = "Anfrage-Pos.")]
        public int RequestItemId { get; set; }

        //public Request.Item RequestItem { get; set; }

        [Display(Name = "Menge")]
        public float Amount { get; set; }

        [Display(Name = "Einzelpreis €")]
        public float Price { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [Display(Name = "Gesamtpreis €")]
        public float Total { get { return Amount * Price; } }
    }
}