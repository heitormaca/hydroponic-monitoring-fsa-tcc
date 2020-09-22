using System.ComponentModel.DataAnnotations;

namespace Hydroponics.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Senha { get; set; }


    }
}