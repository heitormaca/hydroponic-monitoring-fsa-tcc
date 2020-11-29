using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class PlantacaoRepository : IPlantacaoRepository
    {
        private readonly HydroponicsContext context;
        public PlantacaoRepository(HydroponicsContext context)
        {
            this.context = context;
        }

        public async Task<PlantacaoViewModel> GetById(int id)
        {
            return await context.Plantacao
                .Include(a => a.IdBancadaNavigation)
                .Select(d => new PlantacaoViewModel
                {
                    IdPlantacao = d.IdPlantacao,
                    Semeio = d.Semeio,
                    DataInicio = d.DataInicio,
                    DataFim = d.DataFim,
                    NomeBancada = d.IdBancadaNavigation.Nome
                }).FirstOrDefaultAsync(d => d.IdPlantacao == id);

        }

        public async Task<List<PlantacaoViewModel>> GetList()
        {
            return await context.Plantacao
                .Include(a => a.IdBancadaNavigation)
                .Select(d => new PlantacaoViewModel
                {
                    IdPlantacao = d.IdPlantacao,
                    Semeio = d.Semeio,
                    DataInicio = d.DataInicio,
                    DataFim = d.DataFim,
                    NomeBancada = d.IdBancadaNavigation.Nome
                }).ToListAsync();
        }

        public async Task<Plantacao> Post(Plantacao plantacao)
        {
            await context.Plantacao.AddAsync(plantacao);
            await context.SaveChangesAsync();
            return plantacao;
        }
    }
}
