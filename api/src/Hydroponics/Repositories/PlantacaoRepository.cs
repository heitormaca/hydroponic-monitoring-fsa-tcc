using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;

namespace Hydroponics.Repositories
{
    public class PlantacaoRepository : IPlantacaoRepository
    {
        private readonly HydroponicsContext context;
        public PlantacaoRepository(HydroponicsContext context)
        {
            this.context = context;
        }

        //public async Task<PlantacaoViewModel> GetById(int id)
        //{
        //    return await context.Plantacao
        //        .Include(a => a.)

        //}

        //public async Task<List<PlantacaoViewModel>> GetList()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Plantacao> Post(Plantacao plantacao)
        {
            await context.Plantacao.AddAsync(plantacao);
            await context.SaveChangesAsync();
            return plantacao;
        }
    }
}
