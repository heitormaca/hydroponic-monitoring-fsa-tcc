using System.Collections.Generic;
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
    public class EstufaController : ControllerBase
    {
        EstufaRepositorio repositorio = new EstufaRepositorio();

        /// <summary>
        /// Método para cadastrar uma estufa.
        /// </summary>
        /// <param name="estufa">Envia um nome.</param>
        /// <returns>Retorna a estufa cadastrada ou erro 500.</returns>
        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Estufa estufa)
        {
            try
            {
                return Ok(await repositorio.Post(estufa));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar as estufas cadastradas.
        /// </summary>
        /// <returns>Retorna a lista das estufas cadastradas ou erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var list = await repositorio.GetList(); 
                return Ok(list);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}