using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IEstufaRepository
    {
        Task<Estufa> Post(Estufa estufa);
        Task<List<EstufaWithQtdViewModel>> GetList();
        Task<Estufa> GetById(int id);
    }
}