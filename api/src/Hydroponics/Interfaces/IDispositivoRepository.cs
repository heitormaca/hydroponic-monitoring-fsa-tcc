using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<Dispositivo> Post(Dispositivo dispositivo);
        Task<List<DispositivoViewModel>> GetList();
        Task<DispositivoViewModel> GetById(int id);

    }
}