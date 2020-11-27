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

        public async Task<BancadaViewModel> GetById(int id)
        {
            return await context.Bancada
                .Include(d => d.Plantacao)
                    .ThenInclude(d => d.IdBancadaNavigation)
                .Select(d => new BancadaViewModel
                {
                    IdBancada = d.IdBancada,
                    Nome = d.Nome,
                    Plantacoes = d.Plantacao.Select(b => new BancadaPlantacoesViewModel
                    {
                        IdPlantacao = b.IdPlantacao,
                        Semeio = b.Semeio,
                        DataInicio = b.DataInicio,
                        DataFim = b.DataFim,
                        NomeBancada = b.IdBancadaNavigation.Nome
                    }).ToList()
                }).FirstOrDefaultAsync(d => d.IdBancada == id);
        }

        public async Task<List<BancadaListViewModel>> GetList()
        {
            return await context.Bancada
                .Include(a => a.Plantacao)
                .Select(b => new BancadaListViewModel
                {
                    IdBancada = b.IdBancada,
                    Nome = b.Nome,
                    DataInicio = b.DataInicio,
                    Localizacao = b.Localizacao,
                    NomeEstufa = b.IdEstufaNavigation.Nome,
                    NomeDispositivo = b.IdDispositivoNavigation.Nome,
                    QtdPlantacao = b.Plantacao.Count
                })
                .ToListAsync();
        }

        public async Task<Bancada> Post(Bancada bancada)
        {
            await context.Bancada.AddAsync(bancada);
            await context.SaveChangesAsync();
            return bancada;
        }
    }
}