using System.Collections.Generic;

namespace Hydroponics.ViewModel
{
    public class BancadaViewModel
    {
        public int IdBancada { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<BancadaPlantacoesViewModel> Plantacoes { get; set; }
    }
}
