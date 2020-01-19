using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(70)]
        public string Email { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(20)]
        public string Senha { get; set; }
        [Required]
        [Column("imagem", TypeName = "text")]
        public string Imagem { get; set; }
    }
}
