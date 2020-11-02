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
    public class BancadaController : ControllerBase
    {
        private readonly BancadaRepository repository;

        public BancadaController(BancadaRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Método para cadastrar uma bancada.
        /// </summary>
        /// <param name="bancada">Envia um nome, semeio, dataFim, sensorTempBancMax, sensorTempBancMin, sensorTempSolMax, sensorTempSolMin, sensorTempPhMAx, sensorTempPhMin, sensorTempEcMax, sensorTempEcMin e id_estufa.</param>
        /// <returns>Retorna a bancada cadastrada.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Bancada bancada)
        {
            try
            {
                return Ok(await repository.Post(bancada));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar as bancadas cadastradas por uma estufa específica.
        /// </summary>
        /// <param name="idEstufa">Envia opcionalmente o id da estufa.</param>
        /// <returns>Retorna a lista das estufas cadastradas por uma estufa específica ou erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]int? idEstufa)
        {
            try
            {
                if (idEstufa.HasValue) return Ok(await repository.GetList(idEstufa.Value));
                else return Ok(await repository.GetList());
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para buscar uma bancada especifica.
        /// </summary>
        /// <param name="id">Envia o id da bancada.</param>
        /// <returns>Retorna uma bancada específica ou erro 500.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await repository.GetById(id));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}