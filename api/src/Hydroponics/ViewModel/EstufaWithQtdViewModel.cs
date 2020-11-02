using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.ViewModel
{
    //viewmodel de "saida" não precisa ser completa.
    public class EstufaWithQtdViewModel
    {
        public int IdEstufa { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Localizacao { get; set; }
        public int QtdBancada { get; set; }
    }
}
