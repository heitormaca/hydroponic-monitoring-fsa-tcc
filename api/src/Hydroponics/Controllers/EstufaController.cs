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
    public class EstufaController : ControllerBase
    {
        private readonly EstufaRepository repository;

        public EstufaController(EstufaRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Método para cadastrar uma estufa.
        /// </summary>
        /// <param name="estufa"></param>
        /// <returns>Retorna uma mensagem de sucesso ou erro 500.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Estufa estufa)
        {
            try
            {
                await repository.Post(estufa);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Método para listar estufas.
        /// </summary>
        /// <returns>Retorna a lista das estufas cadastradas ou erro 500.</returns>
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
        /// Método para listar bancadas vinculadas a uma estufa especifica.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a lista de bancadas vinculadas a uma estufa específica ou erro 500.</returns>
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