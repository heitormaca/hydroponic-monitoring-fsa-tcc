using System;
namespace Hydroponics.ViewModel
{
    public class BancadaListViewModel
    {
        public int IdBancada { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Localizacao { get; set; }
        public string NomeEstufa { get; set; }
        public string NomeDispositivo { get; set; }
        public int QtdPlantacao { get; set; }
    }
}
