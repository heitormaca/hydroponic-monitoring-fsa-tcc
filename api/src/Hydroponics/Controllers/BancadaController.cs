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
        /// <param name="bancada"></param>
        /// <returns>Retorna uma mensagem de sucerro ou erro 500.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Bancada bancada)
        {
            try
            {
                await repository.Post(bancada);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar bancadas.
        /// </summary>
        /// <returns>Retorna a lista das bancadas cadastradas ou erro 500.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await repository.GetList());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar plantações vinculadas a uma bancada especifica.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a lista de plantações vinculadas a uma bancada específica ou erro 500.</returns>
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