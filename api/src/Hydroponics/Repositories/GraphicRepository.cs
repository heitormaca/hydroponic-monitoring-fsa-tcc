using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.Repositories
{
    public class GraphicRepository
    {
        private readonly HydroponicsContext context;
        public GraphicRepository(HydroponicsContext context)
        {
            this.context = context;
        }

        public async Task<List<GraphicViewModel>> Graphics(int idPlantacao)
        {
            var plantacao = await context.Plantacao
                .Include(d => d.IdBancadaNavigation)
                .FirstOrDefaultAsync(b => b.IdPlantacao == idPlantacao);
            if (plantacao == null) return new List<GraphicViewModel>();
            return await context.Medicao
                .Where(d => d.IdDispositivo == plantacao.IdBancadaNavigation.IdDispositivo)
                .Select(d => new GraphicViewModel
                {
                    SensorTempBanc = new GraphicViewModel.ValueResult
                    {
                        MaxValue = plantacao.TempBancMax,
                        MinValue = plantacao.TempBancMin,
                        Value = d.SensorTempBanc
                    },
                    SensorTempSol = new GraphicViewModel.ValueResult
                    {
                        MaxValue = plantacao.TempSolMax,
                        MinValue = plantacao.TempSolMin,
                        Value = d.SensorTempSol
                    },
                    SensorPh = new GraphicViewModel.ValueResult
                    {
                        MaxValue = plantacao.PhMax,
                        MinValue = plantacao.PhMin,
                        Value = d.SensorPh
                    },
                    SensorEc = new GraphicViewModel.ValueResult
                    {
                        MaxValue = plantacao.EcMax,
                        MinValue = plantacao.EcMin,
                        Value = d.SensorEc
                    },
                    Date = d.DataMedicao,
                }).ToListAsync();
        }
    }
}
