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
    public class UsuarioHabilidadeController : ControllerBase
    {
        IUsuarioHabilidade UsuarioHabilidadeRepo;
        private readonly ILogger<UsuarioHabilidadeController> _logger;

        public UsuarioHabilidadeController(IUsuarioHabilidade UsuarioHabilidadeRepo, ILogger<UsuarioHabilidadeController> logger)
        {
            this.UsuarioHabilidadeRepo = UsuarioHabilidadeRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioHabilidade>> Get()
        {
            return await UsuarioHabilidadeRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UsuarioHabilidade UsuarioHabilidade)
        {
            try
            {
                var result = await UsuarioHabilidadeRepo.Insert(UsuarioHabilidade);
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
        public async Task<IActionResult> Put(int id,[FromBody] UsuarioHabilidade UsuarioHabilidade)
        {
            try
            {
                if(UsuarioHabilidade.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _UsuarioHabilidade = await UsuarioHabilidadeRepo.Select(id);

                if (_UsuarioHabilidade.Id == 0)
                {
                    return NotFound(new Messages("Esta UsuarioHabilidade não existe ou já foi removido." ));
                }

                await UsuarioHabilidadeRepo.Update(UsuarioHabilidade);
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
                var _UsuarioHabilidade = await UsuarioHabilidadeRepo.Select(id);

                if (_UsuarioHabilidade.Id == 0)
                {
                    return NotFound("Esta UsuarioHabilidade não existe ou já foi removido.");
                }

                await UsuarioHabilidadeRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
