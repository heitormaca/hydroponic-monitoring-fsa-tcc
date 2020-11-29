using Hydroponics.Interfaces;
using Hydroponics.Models;
using System;
using System.Threading.Tasks;

namespace Hydroponics.Repositories
{
    public class MedicaoRepository : IMedicaoRepository
    {
        private readonly HydroponicsContext context;
        public MedicaoRepository(HydroponicsContext context)
        {
            this.context = context;
        }
        public async Task<Medicao> Post(Medicao medicao)
        {
            medicao.DataMedicao = DateTime.Now.ToUniversalTime();
            await context.Medicao.AddAsync(medicao);
            await context.SaveChangesAsync();
            return medicao;
        }
    }
}
