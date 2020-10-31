using System.Threading.Tasks;
using Hydroponics.Models;

namespace Hydroponics.Interfaces
{
    public interface IMedicaoRepository
    {
        Task<Medicao> Post(Medicao medicao);
    }
}