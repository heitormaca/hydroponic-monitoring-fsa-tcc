using System.Linq;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Repositories
{
    public class LoginRepositorio : ILoginRepository
    {
        hydroponicsContext context = new hydroponicsContext();
        public Produtor Login(LoginViewModel login)
        {
            Produtor produtor = context.Produtor.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            return produtor;
        }
    }
}