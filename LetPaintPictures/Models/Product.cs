using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public float Price { get; set; }
        
        public int ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        public ProductCategory ProductCategory { get; set; }

        [InverseProperty(nameof(PriceAdjustment.Products))]
        public List<PriceAdjustment> PriceAdjustments { get; set; }
    }
}
