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
            BancadaSensores = new HashSet<BancadaSensores>();
        }

        [Key]
        [Column("id_bancada")]
        public int IdBancada { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("semeio")]
        [StringLength(50)]
        public string Semeio { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime DataInicio { get; set; }
        [Column("dataFim", TypeName = "datetime")]
        public DateTime DataFim { get; set; }
        [Column("statusBancada")]
        public bool? StatusBancada { get; set; }
        [Column("sensorTempBancMax")]
        public double SensorTempBancMax { get; set; }
        [Column("sensorTempBancMin")]
        public double SensorTempBancMin { get; set; }
        [Column("sensorTempSolMax")]
        public double SensorTempSolMax { get; set; }
        [Column("sensorTempSolMin")]
        public double SensorTempSolMin { get; set; }
        [Column("sensorPhMax")]
        public double SensorPhMax { get; set; }
        [Column("sensorPhMin")]
        public double SensorPhMin { get; set; }
        [Column("sensorEcMax")]
        public double SensorEcMax { get; set; }
        [Column("sensorEcMin")]
        public double SensorEcMin { get; set; }
        [Column("id_estufa")]
        public int? IdEstufa { get; set; }

        [ForeignKey(nameof(IdEstufa))]
        [InverseProperty(nameof(Estufa.Bancada))]
        public virtual Estufa IdEstufaNavigation { get; set; }
        [InverseProperty("IdBancadaNavigation")]
        public virtual ICollection<BancadaSensores> BancadaSensores { get; set; }
    }
}
