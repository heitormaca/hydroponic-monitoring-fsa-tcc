using System.Threading.Tasks;
using Hydroponics.Models;
using Hydroponics.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hydroponics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BancadaController : ControllerBase
    {
        BancadaRepositorio repositorio = new BancadaRepositorio();

        /// <summary>
        /// Método para cadastrar uma bancada.
        /// </summary>
        /// <param name="bancada">Envia um nome, semeio, dataFim, sensorTempBancMax, sensorTempBancMin, sensorTempSolMax, sensorTempSolMin, sensorTempPhMAx, sensorTempPhMin, sensorTempEcMax, sensorTempEcMin e estufa.</param>
        /// <returns>Retorna a bancada cadastrada.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Bancada bancada)
        {
           try
           {
               return Ok(await repositorio.Post(bancada));
           }
           catch (System.Exception e)
           {
               return StatusCode(500, e);
           } 
        }

        /// <summary>
        /// Método para listar as bancadas cadastradas.
        /// </summary>
        /// <returns>Retorna a lista das estufas cadastradas ou erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await repositorio.GetList());
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar as bancadas cadastradas por uma estufa específica.
        /// </summary>
        /// <returns>Retorna a lista das estufas cadastradas por uma estufa específica ou erro 500.</returns>
        [Authorize]
        [HttpGet("lista/{id}")]
        public async Task<IActionResult> GetList(int id)
        {
            try
            {
                return Ok(await repositorio.GetList(id));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para buscar uma bancada especifica.
        /// </summary>
        /// <returns>Retorna uma bancada específica ou erro 500.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await repositorio.Get(id));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}