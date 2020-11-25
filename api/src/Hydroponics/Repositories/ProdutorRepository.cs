using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydroponics.Interfaces;
using Hydroponics.Models;
using Hydroponics.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hydroponics.Repositories
{
    public class ProdutorRepository : IProdutorRepository
    {
        private readonly HydroponicsContext context;
        public ProdutorRepository(HydroponicsContext context)
        {
            this.context = context;
        }
        public async Task<Produtor> Post(Produtor produtor)
        {
            await context.Produtor.AddAsync(produtor);
            await context.SaveChangesAsync();
            return produtor;
        }
        public async Task<Produtor> EmailCheck(sendPassViewModel email)
        {
            return await context.Produtor.FirstOrDefaultAsync(u => u.Email == email.Email);    
        }
        public async Task<Produtor> Put(Produtor produtor)
        {
            context.Entry(produtor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return produtor;
        }
        public async Task<List<Produtor>> GetList()
        {
            return await context.Produtor.ToListAsync();
        }

        public async Task<ProdutorDataViewModel> GetById(int id)
        {
            return await context.Produtor.Select(d => new ProdutorDataViewModel
            {
                IdProdutor = d.IdProdutor,
                Nome = d.Nome,
                Email = d.Email,
                Imagem = d.Imagem
            }).FirstOrDefaultAsync(d => d.IdProdutor == id);
        }

        public async Task<Produtor> Login(LoginViewModel login)
        {
            return await context.Produtor.FirstOrDefaultAsync(a => a.Email == login.Email && a.Senha == login.Senha);
        }

        public async Task<Produtor> GetAllById(int id)
        {
            return await context.Produtor.FirstOrDefaultAsync(a => a.IdProdutor == id);
        }
    }
}