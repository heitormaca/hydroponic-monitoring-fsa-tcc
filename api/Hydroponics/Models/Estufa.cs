using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Estufa
    {
        public Estufa()
        {
            Bancada = new HashSet<Bancada>();
        }

        [Key]
        [Column("id_estufa")]
        public int IdEstufa { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty("IdEstufaNavigation")]
        public virtual ICollection<Bancada> Bancada { get; set; }
    }
}
