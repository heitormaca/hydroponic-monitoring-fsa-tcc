using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IBancadaSensoresRepositorio
    {
        Task<BancadaSensores> Post(BancadaSensores bancadaSensores);
    }
}