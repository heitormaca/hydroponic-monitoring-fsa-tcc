using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Bancada
    {
        public Bancada()
        {
            Plantacao = new HashSet<Plantacao>();
        }

        [Key]
        [Column("idBancada")]
        public int IdBancada { get; set; }
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
        [Column("idDispositivo")]
        public int? IdDispositivo { get; set; }

        [ForeignKey(nameof(IdDispositivo))]
        [InverseProperty(nameof(Dispositivo.Bancada))]
        public virtual Dispositivo IdDispositivoNavigation { get; set; }
        [ForeignKey(nameof(IdEstufa))]
        [InverseProperty(nameof(Estufa.Bancada))]
        public virtual Estufa IdEstufaNavigation { get; set; }
        [InverseProperty("IdBancadaNavigation")]
        public virtual ICollection<Plantacao> Plantacao { get; set; }
    }
}
