using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IBancadaRepositorio
    {
        Task<Bancada> Post(Bancada bancada);
        Task<List<Bancada>> GetList();
        Task<List<Bancada>> GetList(int id);
        Task<Bancada> Get(int id);
    }
}