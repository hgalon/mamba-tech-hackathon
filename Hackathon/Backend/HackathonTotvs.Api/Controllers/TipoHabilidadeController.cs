using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonTotvs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoHabilidadeController : ControllerBase
    {
        ITipoHabilidade tipoHabilidadeRepo;
        private readonly ILogger<TipoHabilidadeController> _logger;

        public TipoHabilidadeController(ITipoHabilidade tipoHabilidadeRepo, ILogger<TipoHabilidadeController> logger)
        {
            this.tipoHabilidadeRepo = tipoHabilidadeRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoHabilidade>> Get()
        {
            return await tipoHabilidadeRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoHabilidade tipoHabilidade)
        {
            try
            {
                var result = await tipoHabilidadeRepo.Insert(tipoHabilidade);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id,[FromBody] TipoHabilidade tipoHabilidade)
        {
            try
            {
                if(tipoHabilidade.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _tipoHabilidade = await tipoHabilidadeRepo.Select(id);

                if (_tipoHabilidade.Id == 0)
                {
                    return NotFound(new Messages("Este tipo não existe ou já foi removido." ));
                }

                await tipoHabilidadeRepo.Update(tipoHabilidade);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var _tipoHabilidade = await tipoHabilidadeRepo.Select(id);

                if (_tipoHabilidade.Id == 0)
                {
                    return NotFound("Este tipo não existe ou já foi removido.");
                }

                await tipoHabilidadeRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
