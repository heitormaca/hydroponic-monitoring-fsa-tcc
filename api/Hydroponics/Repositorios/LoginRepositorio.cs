using System.Linq;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        HydroponicsContext context = new HydroponicsContext();
        public Usuario Login(LoginViewModel login)
        {
            Usuario usuario = context.Usuario.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            return usuario;
        }
    }
}