using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Plantacao
    {
        [Key]
        [Column("idPlantacao")]
        public int IdPlantacao { get; set; }
        [Column("observacoes", TypeName = "text")]
        public string Observacoes { get; set; }
        [Required]
        [Column("semeio")]
        [StringLength(50)]
        public string Semeio { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }
        [Column("dataFim", TypeName = "datetime")]
        public DateTime DataFim { get; set; }
        public double TempBancMax { get; set; }
        public double TempBancMin { get; set; }
        public double TempSolMax { get; set; }
        public double TempSolMin { get; set; }
        public double PhMax { get; set; }
        public double PhMin { get; set; }
        public double EcMax { get; set; }
        public double EcMin { get; set; }
        [Column("idBancada")]
        public int? IdBancada { get; set; }

        [ForeignKey(nameof(IdBancada))]
        [InverseProperty(nameof(Bancada.Plantacao))]
        public virtual Bancada IdBancadaNavigation { get; set; }
    }
}
