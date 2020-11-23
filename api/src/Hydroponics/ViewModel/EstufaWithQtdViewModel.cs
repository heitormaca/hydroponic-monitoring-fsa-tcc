using System;

namespace Hydroponics.ViewModel
{
    public class EstufaWithQtdViewModel
    {
        public int IdEstufa { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Localizacao { get; set; }
        public int QtdBancada { get; set; }
    }
}
