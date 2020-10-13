using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class BancadaFisica
    {
        public BancadaFisica()
        {
            BancadaVirtual = new HashSet<BancadaVirtual>();
        }

        [Key]
        [Column("idBancadaFisica")]
        public int IdBancadaFisica { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
        [Column("idEstufa")]
        public int? IdEstufa { get; set; }

        [ForeignKey(nameof(IdEstufa))]
        [InverseProperty(nameof(Estufa.BancadaFisica))]
        public virtual Estufa IdEstufaNavigation { get; set; }
        [InverseProperty("IdBancadaFisicaNavigation")]
        public virtual ICollection<BancadaVirtual> BancadaVirtual { get; set; }
    }
}
