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

        /// <summary>
        /// Método para retornar dois tipos de listas para as Estufas.
        /// </summary>
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

        /// <summary>
        /// Método para buscar uma estufa especifica.
        /// </summary>
        /// <param name="id">Envia o id da estufa.</param>
        /// <returns>Retorna uma estufa específica ou erro 500.</returns>
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

