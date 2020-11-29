using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Produtor
    {
        public Produtor()
        {
            Estufa = new HashSet<Estufa>();
        }

        [Key]
        [Column("idProdutor")]
        public int IdProdutor { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(70)]
        public string Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(70)]
        public string Email { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(255)]
        public string Senha { get; set; }
        [Column("imagem", TypeName = "text")]
        public string Imagem { get; set; }

        [InverseProperty("IdProdutorNavigation")]
        public virtual ICollection<Estufa> Estufa { get; set; }
    }
}
