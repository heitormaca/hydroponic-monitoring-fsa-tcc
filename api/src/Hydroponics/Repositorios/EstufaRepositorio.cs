//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Hydroponics.Interfaces;
//using Hydroponics.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Hydroponics.Repositorios
//{
//    public class EstufaRepositorio : IEstufaRepositorio
//    {
//        HydroponicsContext context = new HydroponicsContext();

//        public async Task<List<Estufa>> GetList()
//        {
//            return await context.Estufa
//                .Include(a => a.Bancada)
//                .ToListAsync();
//        }

//        public async Task<Estufa> Post(Estufa estufa)
//        {    
//            await context.Estufa.AddAsync(estufa);
//            await context.SaveChangesAsync();
//            return estufa;
//        }
//    }
//}