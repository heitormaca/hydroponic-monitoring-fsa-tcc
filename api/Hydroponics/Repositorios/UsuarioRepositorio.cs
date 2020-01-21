using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;

namespace Hydroponics.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        HydroponicsContext context = new HydroponicsContext();
        public async Task<Usuario> Post(Usuario usuario)
        {
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }
    }
}