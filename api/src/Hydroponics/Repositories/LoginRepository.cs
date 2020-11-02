using System.Linq;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly hydroponicsContext context;
        public LoginRepository(hydroponicsContext context)
        {
            this.context = context;
        }
        public Produtor Login(LoginViewModel login)
        {
            Produtor produtor = context.Produtor.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
            return produtor;
        }
    }
}