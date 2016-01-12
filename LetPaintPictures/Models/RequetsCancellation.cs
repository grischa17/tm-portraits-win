using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class RequestCancellation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestHeadId { get; set; }

        [ForeignKey(nameof(RequestHeadId))]
        public RequestHead Head { get; set; }

        [Required]
        [MaxLength(256)]
        public string Reason { get; set; }
    }
}
