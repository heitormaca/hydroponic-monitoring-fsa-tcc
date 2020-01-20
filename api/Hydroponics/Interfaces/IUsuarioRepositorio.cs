using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Post(Usuario usuario);
    }
}