using System.ComponentModel.DataAnnotations;

namespace Hydroponics.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength (70)]
        public string Email { get; set; }
    }
}