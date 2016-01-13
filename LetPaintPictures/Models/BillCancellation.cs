using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class BillCancellation
    {
        [Key, ForeignKey(nameof(Head))]
        public int Id { get; set; }
        
        public BillHead Head { get; set; }

        [Required]
        [MaxLength(256)]
        public string Reason { get; set; }
    }
}
