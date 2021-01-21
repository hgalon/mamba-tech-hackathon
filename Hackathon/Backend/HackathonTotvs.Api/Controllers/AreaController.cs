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
    public class AreaController : ControllerBase
    {
        IArea areaRepo;
        private readonly ILogger<AreaController> _logger;

        public AreaController(IArea areaRepo, ILogger<AreaController> logger)
        {
            this.areaRepo = areaRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Area>> Get()
        {
            return await areaRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Area Area)
        {
            try
            {
                var result = await areaRepo.Insert(Area);
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
        public async Task<IActionResult> Put(int id,[FromBody] Area Area)
        {
            try
            {
                if(Area.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _Area = await areaRepo.Select(id);

                if (_Area.Id == 0)
                {
                    return NotFound(new Messages("Esta Area não existe ou já foi removido." ));
                }

                await areaRepo.Update(Area);
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
                var _Area = await areaRepo.Select(id);

                if (_Area.Id == 0)
                {
                    return NotFound("Esta Area não existe ou já foi removido.");
                }

                await areaRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
