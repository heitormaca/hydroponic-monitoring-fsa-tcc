using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class EstufaRepository : IEstufaRepository
    {
        private readonly HydroponicsContext context;
        public EstufaRepository(HydroponicsContext context)
        {
            this.context = context;
        }

        public async Task<EstufaViewModel> GetById(int id)
        {
            return await context.Estufa
                .Include(d => d.Bancada)
                    .ThenInclude(d => d.IdDispositivoNavigation)
                .Include(d => d.Bancada)
                    .ThenInclude(d => d.IdEstufaNavigation)
                .Select(d => new EstufaViewModel
                {
                    IdEstufa = d.IdEstufa,
                    Nome = d.Nome,
                    Bancadas = d.Bancada.Select(b => new EstufaBancadasViewModel
                    {
                        IdBancada = b.IdBancada,
                        Nome = b.Nome,
                        DataInicio = b.DataInicio,
                        Localizacao = b.Localizacao,
                        NomeEstufa = b.IdEstufaNavigation.Nome,
                        NomeDispositivo = b.IdDispositivoNavigation.Nome,
                        QtdPlantacao = b.Plantacao.Count
                    }).ToList()
                })
                .FirstOrDefaultAsync(d => d.IdEstufa == id);
        }

        public async Task<List<EstufaListViewModel>> GetList()
        {
            return await context.Estufa
                .Include(a => a.Bancada)
                .Select(b => new EstufaListViewModel
                {
                    IdEstufa = b.IdEstufa, 
                    Nome = b.Nome,
                    DataInicio = b.DataInicio,
                    Localizacao = b.Localizacao,
                    QtdBancada = b.Bancada.Count
                })
                .ToListAsync();
        }

        public async Task<Estufa> Post(Estufa estufa)
        {
            await context.Estufa.AddAsync(estufa);
            await context.SaveChangesAsync();
            return estufa;
        }
    }
}