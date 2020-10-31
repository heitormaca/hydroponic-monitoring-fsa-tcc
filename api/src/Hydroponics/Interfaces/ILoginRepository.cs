using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface ILoginRepository
    {
        Produtor Login(LoginViewModel login);
    }
}