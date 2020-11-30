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
    public class DispositivoController : ControllerBase
    {
        private readonly DispositivoRepository repository;
        public DispositivoController(DispositivoRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Método para cadastrar um dispositivo.
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns>Retorna mensagem de sucesso ou erro 500.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Dispositivo dispositivo)
        {
            try
            {
                await repository.Post(dispositivo);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar dispositivos que não são vinculados a uma bancada.
        /// </summary>
        /// <returns>Retorna a lista dos dispositivos que não são vinculados a uma bancada ou erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] bool? naoMostrarVinculadas)
        {
            try
            {
                return Ok(await repository.GetList(naoMostrarVinculadas));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para buscar um dispositivo especifico.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um dispositivo específico ou erro 500.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await repository.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
