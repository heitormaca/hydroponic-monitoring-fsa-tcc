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
    public class BancadaSensoresController : ControllerBase
    {
        BancadaSensoresRepositorio repositorio = new BancadaSensoresRepositorio();

        /// <summary>
        /// Método para cadastrar um conjunto de dados dos sensores.
        /// </summary>
        /// <param name="bancadaSensores">Envia um sensorTempBanc, sensorTempSol, sensorPh, sensorEc e id_bancada.</param>
        /// <returns>Retorna a estufa cadastrada ou erro 500.</returns>
        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(BancadaSensores bancadaSensores)
        {
            try
            {
                return Ok(await repositorio.Post(bancadaSensores));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}