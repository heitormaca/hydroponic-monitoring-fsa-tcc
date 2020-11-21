using System.ComponentModel.DataAnnotations;

namespace Hydroponics.ViewModel
{
    public class UpdatePasswordViewModel
    {
        [Required]
        [StringLength (255, MinimumLength = 5)]
        public string Senha { get; set; }
    }
}