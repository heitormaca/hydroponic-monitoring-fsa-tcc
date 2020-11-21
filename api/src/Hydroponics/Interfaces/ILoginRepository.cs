using Hydroponics.Models;
using Hydroponics.ViewModel;
using System.Threading.Tasks;

namespace Hydroponics.Interfaces
{
    public interface ILoginRepository
    {
        Task<Produtor> Login(LoginViewModel login);
    }
}