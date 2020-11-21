using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly HydroponicsContext context;
        public LoginRepository(HydroponicsContext context)
        {
            this.context = context;
        }
        public async Task<Produtor> Login(LoginViewModel login)
        {
            Produtor produtor = await context
                .Produtor
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);
            return produtor;
        }
    }
}