using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Estufa
    {
        public Estufa()
        {
            BancadaFisica = new HashSet<BancadaFisica>();
        }

        [Key]
        [Column("idEstufa")]
        public int IdEstufa { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }
        [Column("idUsuario")]
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Estufa))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdEstufaNavigation")]
        public virtual ICollection<BancadaFisica> BancadaFisica { get; set; }
    }
}
