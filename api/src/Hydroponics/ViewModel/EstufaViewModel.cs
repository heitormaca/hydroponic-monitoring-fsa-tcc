﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.ViewModel
{
    public class EstufaViewModel
    {
        public int IdEstufa { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<EstufaBancadasViewModel> Bancadas { get; set; }
    }
}
