using System.ComponentModel.DataAnnotations;

namespace Hydroponics.ViewModel
{
    public class SendPassViewModel
    {
        [Required]
        [StringLength (70)]
        public string Email { get; set; }
    }
}