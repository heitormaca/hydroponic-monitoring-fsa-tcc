using System;
using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PlantacaoController : ControllerBase
    {
        private readonly PlantacaoRepository repository;
        public PlantacaoController(PlantacaoRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// Método para cadastrar um conjunto de dados dos sensores.
        /// </summary>
        /// <param name="plantacao">Envia um sensorTempBanc, sensorTempSol, sensorPh, sensorEc e id_bancada.</param>
        /// <returns>Retorna a estufa cadastrada ou erro 500.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Plantacao plantacao)
        {
            try
            {
                await repository.Post(plantacao);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

