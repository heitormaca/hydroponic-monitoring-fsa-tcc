using Hydroponics.Models;
using Hydroponics.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicaoController : ControllerBase
    {
        private readonly MedicaoRepository repository;

        public MedicaoController(MedicaoRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Método para cadastrar uma medição de um dispositivo específico.
        /// </summary>
        /// <param name="medicao"></param>
        /// <returns>Retorna os dados da medição de um dispositivo específico ou erro 500.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Medicao medicao)
        {
            try
            {
                await repository.Post(medicao);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
