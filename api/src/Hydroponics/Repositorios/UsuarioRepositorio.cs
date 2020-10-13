//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Hydroponics.Interfaces;
//using Hydroponics.Models;
//using Hydroponics.ViewModel;
//using Microsoft.EntityFrameworkCore;

//namespace Hydroponics.Repositorios
//{
//    public class UsuarioRepositorio : IUsuarioRepositorio
//    {
//        HydroponicsContext context = new HydroponicsContext();
//        public async Task<Usuario> Post(Usuario usuario)
//        {
//            await context.Usuario.AddAsync(usuario);
//            await context.SaveChangesAsync();
//            return usuario;
//        }
//        public Usuario VerificacaoEmail(ForgotPasswordViewModel verificacao)
//        {
//            Usuario usuario = context.Usuario.FirstOrDefault(u => u.Email == verificacao.Email);
//            return usuario;
//        }
//        public async Task<Usuario> Put(Usuario usuario) 
//        {
//            context.Entry (usuario).State = EntityState.Modified;
//            await context.SaveChangesAsync();
//            return usuario;
//        }
//        public async Task<Usuario> GetById(int id) 
//        {
//            return await context.Usuario.FirstOrDefaultAsync(a => a.IdUsuario == id);
//        }

//        public async Task<List<Usuario>> GetList()
//        {
//            return await context.Usuario.ToListAsync();
//        }
//    }
//}