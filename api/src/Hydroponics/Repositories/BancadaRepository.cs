using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Microsoft.EntityFrameworkCore;
using Hydroponics.ViewModel;

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

        public async Task<List<ListBancadasByIdViewModel>> GetList(int id)
        {
            return await context.Bancada.Select(d => new ListBancadasByIdViewModel
            { 
                IdBancada = d.IdBancada,
                IdEstufa = (int)d.IdEstufa,
                nome = d.Nome,
                DataInicio = d.DataInicio,
                Localizacao = d.Localizacao,
                IdDispositivo = (int)d.IdDispositivo
            }).Where(x => x.IdEstufa == id).ToListAsync();
        }

        public async Task<Bancada> Post(Bancada bancada)
        {
            await context.Bancada.AddAsync(bancada);
            await context.SaveChangesAsync();
            return bancada;
        }
    }
}