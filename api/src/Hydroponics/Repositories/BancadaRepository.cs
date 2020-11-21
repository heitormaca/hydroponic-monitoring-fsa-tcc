using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class BancadaRepository : IBancadaRepository
    {
        public BancadaRepository(HydroponicsContext context)
        {
            this.context = context;
        }
        private readonly HydroponicsContext context;

        public async Task<Bancada> GetById(int id)
        {
            return await context.Bancada.FirstOrDefaultAsync(a => a.IdBancada == id);
        }

        public async Task<List<Bancada>> GetList()
        {
            return await context.Bancada.ToListAsync();
        }

        public async Task<List<Bancada>> GetList(int id)
        {
            return await context.Bancada.Where(x => x.IdEstufa == id).ToListAsync();
        }

        public async Task<Bancada> Post(Bancada bancada)
        {
            await context.Bancada.AddAsync(bancada);
            await context.SaveChangesAsync();
            return bancada;
        }
    }
}