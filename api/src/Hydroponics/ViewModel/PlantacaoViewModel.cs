using System;

namespace Hydroponics.ViewModel
{
    public class PlantacaoViewModel
    {
        public int IdPlantacao { get; set; }
        public string Semeio { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string NomeBancada { get; set; }
    }
}
