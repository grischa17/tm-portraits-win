using System.ComponentModel.DataAnnotations;

namespace TuRM.User.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}