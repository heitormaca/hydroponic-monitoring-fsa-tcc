using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Interfaces
{
    public interface ILoginRepositorio
    {
        Usuario Login (LoginViewModel login);
    }
}