using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Medicao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("dispositivo")]
        [StringLength(50)]
        public string Dispositivo { get; set; }
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
    }
}
