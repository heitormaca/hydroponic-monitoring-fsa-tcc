//using System.Threading.Tasks;
//using Hydroponics.Interfaces;
//using Hydroponics.Models;

//namespace Hydroponics.Repositorios
//{
//    public class BancadaSensoresRepositorio : IBancadaSensoresRepositorio
//    {
//        HydroponicsContext context = new HydroponicsContext();
//        public async Task<BancadaSensores> Post(BancadaSensores bancadaSensores)
//        {
//            await context.BancadaSensores.AddAsync(bancadaSensores);
//            await context.SaveChangesAsync();
//            return bancadaSensores;
//        }
//    }
//}