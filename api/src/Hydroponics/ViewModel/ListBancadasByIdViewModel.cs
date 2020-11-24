using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.ViewModel
{
    public class ListBancadasByIdViewModel
    {
        public int IdBancada { get; set; }
        public string nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Localizacao { get; set; }
        public int IdEstufa { get; set; }
        public int IdDispositivo { get; set; }
    }
}
