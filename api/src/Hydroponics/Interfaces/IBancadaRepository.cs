using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IBancadaRepository
    {
        Task<Bancada> Post(Bancada bancada);
        Task<List<Bancada>> GetList();
        Task<List<Bancada>> GetList(int id);

        Task<Bancada> GetById(int id);
    }
}