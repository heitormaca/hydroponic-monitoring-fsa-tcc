using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Medicao
    {
        [Key]
        [Column("idMedicao")]
        public int IdMedicao { get; set; }
        [Column("dataMedicao", TypeName = "datetime")]
        public DateTime? DataMedicao { get; set; }
        [Column("sensorTempBanc")]
        public double SensorTempBanc { get; set; }
        [Column("sensorTempSol")]
        public double SensorTempSol { get; set; }
        [Column("sensorPh")]
        public double SensorPh { get; set; }
        [Column("sensorEc")]
        public double SensorEc { get; set; }
        [Column("idDispositivo")]
        public int? IdDispositivo { get; set; }

        [ForeignKey(nameof(IdDispositivo))]
        [InverseProperty(nameof(Dispositivo.Medicao))]
        public virtual Dispositivo IdDispositivoNavigation { get; set; }
    }
}
