using System.Linq;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginRepository(hydroponicsContext context)
        {
            this.context = context;
        }
        private readonly hydroponicsContext context;
        public Produtor Login(LoginViewModel login)
        {
            Produtor produtor = context.Produtor.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            return produtor;
        }
    }
}