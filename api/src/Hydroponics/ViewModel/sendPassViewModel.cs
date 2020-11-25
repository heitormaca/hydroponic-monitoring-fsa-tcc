using System.ComponentModel.DataAnnotations;

namespace Hydroponics.ViewModel
{
    public class sendPassViewModel
    {
        [Required]
        [StringLength (70)]
        public string Email { get; set; }
    }
}