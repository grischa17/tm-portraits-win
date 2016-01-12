using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class RequestItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestHeadId { get; set; }

        [ForeignKey(nameof(RequestHeadId))]
        public RequestHead RequestHead { get; set; }
        
        [MaxLength(64)]
        public string Name { get; set; }
        
        public float Amount { get; set; }
        
        public float Price { get; set; }

        //[InverseProperty(nameof(BillItem.RequestItem))]
        //public List<BillItem> BillItems { get; set; }
    }
}