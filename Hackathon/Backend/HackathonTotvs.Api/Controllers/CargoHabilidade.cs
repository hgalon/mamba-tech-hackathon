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
    public class CargoHabilidadeController : ControllerBase
    {
        ICargoHabilidade CargoHabilidadeRepo;
        private readonly ILogger<CargoHabilidadeController> _logger;

        public CargoHabilidadeController(ICargoHabilidade CargoHabilidadeRepo, ILogger<CargoHabilidadeController> logger)
        {
            this.CargoHabilidadeRepo = CargoHabilidadeRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CargoHabilidade>> Get()
        {
            return await CargoHabilidadeRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CargoHabilidade CargoHabilidade)
        {
            try
            {
                var result = await CargoHabilidadeRepo.Insert(CargoHabilidade);
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
        public async Task<IActionResult> Put(int id,[FromBody] CargoHabilidade CargoHabilidade)
        {
            try
            {
                if(CargoHabilidade.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _CargoHabilidade = await CargoHabilidadeRepo.Select(id);

                if (_CargoHabilidade.Id == 0)
                {
                    return NotFound(new Messages("Esta CargoHabilidade não existe ou já foi removido." ));
                }

                await CargoHabilidadeRepo.Update(CargoHabilidade);
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
                var _CargoHabilidade = await CargoHabilidadeRepo.Select(id);

                if (_CargoHabilidade.Id == 0)
                {
                    return NotFound("Esta CargoHabilidade não existe ou já foi removido.");
                }

                await CargoHabilidadeRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
