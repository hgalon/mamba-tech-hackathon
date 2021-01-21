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
    public class HabilidadeController : ControllerBase
    {
        IHabilidade habilidadeRepo;
        private readonly ILogger<HabilidadeController> _logger;

        public HabilidadeController(IHabilidade habilidadeRepo, ILogger<HabilidadeController> logger)
        {
            this.habilidadeRepo = habilidadeRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Habilidade>> Get()
        {
            return await habilidadeRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Habilidade habilidade)
        {
            try
            {
                var result = await habilidadeRepo.Insert(habilidade);
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
        public async Task<IActionResult> Put(int id, [FromBody] Habilidade habilidade)
        {
            try
            {
                if (habilidade.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _habilidade = await habilidadeRepo.Select(id);

                if (_habilidade.Id == 0)
                {
                    return NotFound(new Messages("Esta habilidade não existe ou já foi removido."));
                }

                await habilidadeRepo.Update(habilidade);
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
                var _habilidade = await habilidadeRepo.Select(id);

                if (_habilidade.Id == 0)
                {
                    return NotFound("Esta habilidade não existe ou já foi removido.");
                }

                await habilidadeRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
