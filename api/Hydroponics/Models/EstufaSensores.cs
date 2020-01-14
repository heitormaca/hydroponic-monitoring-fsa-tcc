using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class EstufaSensores
    {
        [Key]
        [Column("id_estufaSensores")]
        public int IdEstufaSensores { get; set; }
        [Column("sensorTempExterno")]
        public double SensorTempExterno { get; set; }
        [Column("id_estufa")]
        public int? IdEstufa { get; set; }

        [ForeignKey(nameof(IdEstufa))]
        [InverseProperty(nameof(Estufa.EstufaSensores))]
        public virtual Estufa IdEstufaNavigation { get; set; }
    }
}
