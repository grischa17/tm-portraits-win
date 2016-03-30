using System.ComponentModel.DataAnnotations;

namespace TuRM.User.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
