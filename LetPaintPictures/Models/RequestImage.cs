using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetPaintPictures.Models
{
    public class RequestImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RequestHeadId { get; set; }

        [ForeignKey(nameof(RequestHeadId))]
        public RequestHead RequestHead { get; set; }

        public byte[] Data { get; set; }
    }
}