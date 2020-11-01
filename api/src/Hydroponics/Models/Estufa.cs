using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydroponics.Models
{
    public partial class Estufa
    {
        public Estufa()
        {
            Bancada = new HashSet<Bancada>();
        }

        [Key]
        [Column("idEstufa")]
        public int IdEstufa { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("dataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
        [Column("idProdutor")]
        public int? IdProdutor { get; set; }

        [ForeignKey(nameof(IdProdutor))]
        [InverseProperty(nameof(Produtor.Estufa))]
        public virtual Produtor IdProdutorNavigation { get; set; }
        [InverseProperty("IdEstufaNavigation")]
        public virtual ICollection<Bancada> Bancada { get; set; }
    }
}
