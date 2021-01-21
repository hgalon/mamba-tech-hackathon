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
    public class TrilhaController : ControllerBase
    {
        ITrilha cargoRepo;
        private readonly ILogger<TrilhaController> _logger;

        public TrilhaController(ITrilha cargoRepo, ILogger<TrilhaController> logger)
        {
            this.cargoRepo = cargoRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Trilha>> Get()
        {
            return await cargoRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Trilha cargo)
        {
            try
            {
                var result = await cargoRepo.Insert(cargo);
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
        public async Task<IActionResult> Put(int id,[FromBody] Trilha cargo)
        {
            try
            {
                if(cargo.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _cargo = await cargoRepo.Select(id);

                if (_cargo.Id == 0)
                {
                    return NotFound(new Messages("Este cargo não existe ou já foi removido." ));
                }

                await cargoRepo.Update(cargo);
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
                var _cargo = await cargoRepo.Select(id);

                if (_cargo.Id == 0)
                {
                    return NotFound("Este cargo não existe ou já foi removido.");
                }

                await cargoRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
