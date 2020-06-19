using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IEstufaRepositorio
    {
        Task<Estufa> Post(Estufa estufa);
        Task<List<Estufa>> GetList();
    }
}