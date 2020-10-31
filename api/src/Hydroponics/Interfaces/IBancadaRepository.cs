using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IBancadaRepository
    {
        Task<Bancada> Post(Bancada bancada);
        Task<List<Bancada>> GetList();
    }
}