using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface IProdutorRepository
    {
        Task<Produtor> Post(Produtor produtor);
        Produtor EmailCheck(ForgotPasswordViewModel email);
        Task<Produtor> Put(Produtor produtor);
        Task<Produtor> GetById(int id);
        Task<List<Produtor>> GetList();
    }
}