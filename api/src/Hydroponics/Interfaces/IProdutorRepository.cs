using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IProdutorRepository
    {
        Task<Produtor> Post(Produtor produtor);
        Task<Produtor> EmailCheck(SendPassViewModel email);
        Task<Produtor> Put(Produtor produtor);
        Task<ProdutorDataViewModel> GetById(int id);
        Task<List<Produtor>> GetList();
        Task<Produtor> Login(LoginViewModel login);
        Task<Produtor> GetAllById(int id);
    }
}