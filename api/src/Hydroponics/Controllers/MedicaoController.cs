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
        /// Método para cadastrar uma medição.
        /// </summary>
        /// <param name="medicao">Envia um nome.</param>
        /// <returns>Retorna mensagem de sucesso ou erro 500.</returns>
        [Authorize]
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
