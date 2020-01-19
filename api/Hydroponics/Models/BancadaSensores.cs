using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class BancadaSensores
    {
        [Key]
        [Column("id_bancadaSensores")]
        public int IdBancadaSensores { get; set; }
        [Column("sensorTempBanc")]
        public double SensorTempBanc { get; set; }
        [Column("sensorTempSol")]
        public double SensorTempSol { get; set; }
        [Column("sensorPh")]
        public double SensorPh { get; set; }
        [Column("sensorEc")]
        public double SensorEc { get; set; }
        [Column("id_bancada")]
        public int? IdBancada { get; set; }

        [ForeignKey(nameof(IdBancada))]
        [InverseProperty(nameof(Bancada.BancadaSensores))]
        public virtual Bancada IdBancadaNavigation { get; set; }
    }
}
