using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydroponics.Repositories
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly HydroponicsContext context;
        public DispositivoRepository(HydroponicsContext context)
        {
            this.context = context;
        }
        public async Task<DispositivoViewModel> GetById(int id)
        {
            return await context.Dispositivo
                .Select(d => new DispositivoViewModel
                {
                    IdDispositivo = d.IdDispositivo,
                    Nome = d.Nome
                }).FirstOrDefaultAsync(d => d.IdDispositivo == id);
        }

        public async Task<List<DispositivoViewModel>> GetList(bool? naoMostrarVinculadas)
        {
            var query = context.Dispositivo.Include(d => d.Bancada).AsQueryable();

            if (naoMostrarVinculadas.HasValue && naoMostrarVinculadas.Value)
            {
                query = query.Where(d => d.Bancada.Count <= 0);
            }

            return await query
                .Select(d => new DispositivoViewModel
                {
                    IdDispositivo = d.IdDispositivo,
                    Nome = d.Nome
                }).ToListAsync();
        }

        public async Task<Dispositivo> Post(Dispositivo dispositivo)
        {
            await context.Dispositivo.AddAsync(dispositivo);
            await context.SaveChangesAsync();
            return dispositivo;
        }
    }
}
