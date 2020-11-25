using System;

namespace Hydroponics.ViewModel
{
    public class EstufaBancadasViewModel
    {
        public int IdBancada { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Localizacao { get; set; }
        public string nomeEstufa { get; set; }
        public string nomeDispositivo { get; set; }
        public int QtdPlantacao { get; set; }
    }
}
