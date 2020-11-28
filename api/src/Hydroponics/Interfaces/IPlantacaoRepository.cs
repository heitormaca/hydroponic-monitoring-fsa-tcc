using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IPlantacaoRepository
    {
        Task<Plantacao> Post(Plantacao plantacao);
        //Task<PlantacaoViewModel> GetById(int id);
        //Task<List<PlantacaoViewModel>> GetList();
    }
}