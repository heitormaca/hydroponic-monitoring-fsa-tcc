using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IBancadaRepository
    {
        Task<Bancada> Post(Bancada bancada);
        Task<List<BancadaListViewModel>> GetList();
        Task<BancadaViewModel> GetById(int id);
    }
}