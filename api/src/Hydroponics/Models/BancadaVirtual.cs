using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class BancadaVirtual
    {
        [Key]
        [Column("idBancadaVirtual")]
        public int IdBancadaVirtual { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("semeio")]
        [StringLength(50)]
        public string Semeio { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }
        [Column("dataFim", TypeName = "datetime")]
        public DateTime DataFim { get; set; }
        [Column("statusBancada")]
        public bool? StatusBancada { get; set; }
        public double TempBancMax { get; set; }
        public double TempBancMin { get; set; }
        public double TempSolMax { get; set; }
        public double TempSolMin { get; set; }
        public double PhMax { get; set; }
        public double PhMin { get; set; }
        public double EcMax { get; set; }
        public double EcMin { get; set; }
        [Required]
        [Column("dispositivo")]
        [StringLength(50)]
        public string Dispositivo { get; set; }
        [Column("idBancadaFisica")]
        public int? IdBancadaFisica { get; set; }

        [ForeignKey(nameof(IdBancadaFisica))]
        [InverseProperty(nameof(BancadaFisica.BancadaVirtual))]
        public virtual BancadaFisica IdBancadaFisicaNavigation { get; set; }
    }
}
