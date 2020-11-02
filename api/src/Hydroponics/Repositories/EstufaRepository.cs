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
        private readonly hydroponicsContext context;
        public EstufaRepository(hydroponicsContext context)
        {
            this.context = context;
        }
        public async Task<List<EstufaWithQtdViewModel>> GetList()
        {
            return await context.Estufa
                .Include(a => a.Bancada)
                .Select(b => new EstufaWithQtdViewModel
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
        public async Task<Estufa> GetById(int id)
        {
            return await context.Estufa.FirstOrDefaultAsync(x => x.IdEstufa == id);
        }
    }
}