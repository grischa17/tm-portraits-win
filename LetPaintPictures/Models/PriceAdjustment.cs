using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class PriceAdjustment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public float Adjustment { get; set; }

        [InverseProperty(nameof(Product.PriceAdjustments))]
        public List<Product> Products { get; set; }
    }
}
