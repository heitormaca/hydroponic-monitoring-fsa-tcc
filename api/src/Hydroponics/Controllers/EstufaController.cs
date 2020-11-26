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
        /// <param name="estufa">Envia um nome.</param>
        /// <returns>Retorna mensagem de sucesso ou erro 500.</returns>
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
        /// Método para retornar dois tipos de listas para as Estufas.
        /// </summary>
        /// <param name="idEstufa">Envia opcionalmente um idEstufa</param>
        /// <returns>Retorna a lista das estufas cadastradas, ou a lista de bancadas do Id da estufa indicada, ou erro 500.</returns>
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
        /// Método para buscar uma estufa especifica.
        /// </summary>
        /// <param name="id">Envia o id da estufa.</param>
        /// <returns>Retorna uma estufa específica ou erro 500.</returns>
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