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

        public double TempBancMax { get; set; }
        public double TempBancMin { get; set; }
        public double TempSolMax { get; set; }
        public double TempSolMin { get; set; }
        public double PhMax { get; set; }
        public double PhMin { get; set; }
        public double EcMax { get; set; }
        public double EcMin { get; set; }
    }
}
