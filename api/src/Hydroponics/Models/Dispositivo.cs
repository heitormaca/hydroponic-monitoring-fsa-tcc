using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Dispositivo
    {
        public Dispositivo()
        {
            Bancada = new HashSet<Bancada>();
            Medicao = new HashSet<Medicao>();
        }

        [Key]
        [Column("idDispositivo")]
        public int IdDispositivo { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("endMac")]
        [StringLength(50)]
        public string EndMac { get; set; }

        [InverseProperty("IdDispositivoNavigation")]
        public virtual ICollection<Bancada> Bancada { get; set; }
        [InverseProperty("IdDispositivoNavigation")]
        public virtual ICollection<Medicao> Medicao { get; set; }
    }
}
