using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class BillItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int HeadId { get; set; }

        [ForeignKey(nameof(HeadId))]
        public BillHead Head { get; set; }
        
        //public int ProductId { get; set; }

        //[ForeignKey(nameof(ProductId))]
        //public Product Product { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public int RequestItemId { get; set; }

        //[ForeignKey(nameof(RequestItemId))]
        //public RequestItem RequestItem { get; set; }

        public float Amount { get; set; }

        public float Price { get; set; }
    }
}
