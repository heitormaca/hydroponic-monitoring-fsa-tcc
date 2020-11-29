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
        private readonly GraphicRepository graphicRepository;

        public PlantacaoController(PlantacaoRepository repository, GraphicRepository graphicRepository)
        {
            this.repository = repository;
            this.graphicRepository = graphicRepository;
        }
        /// <summary>
        /// Método para cadastrar uma plantação.
        /// </summary>
        /// <param name="plantacao"></param>
        /// <returns>Retorna uma mensagem de sucesso ou erro 500.</returns>
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

        /// <summary>
        /// Método para listar plantações.
        /// </summary>
        /// <returns>Retorna a lista das plantações cadastradas ou erro 500.</returns>
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
        /// Método para buscar uma plantação especifica.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma plantação específica ou erro 500.</returns>
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

        /// <summary>
        /// Método para listar os dados das medições de uma plantação específica.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna os dados das medições de uma plantação específica ou erro 500.</returns>
        [Authorize]
        [HttpGet("{id}/graphics")]
        public async Task<IActionResult> Graphics(int id)
        {
            try
            {
                return Ok(await graphicRepository.Graphics(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}

