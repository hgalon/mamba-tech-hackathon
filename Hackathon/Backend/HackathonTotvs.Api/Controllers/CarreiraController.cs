﻿using HackathonTotvs.Domain.Interfaces;
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
    public class CarreiraController : ControllerBase
    {
        ICarreira carreiraRepo;
        private readonly ILogger<CarreiraController> _logger;

        public CarreiraController(ICarreira carreiraRepo, ILogger<CarreiraController> logger)
        {
            this.carreiraRepo = carreiraRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Carreira>> Get()
        {
            return await carreiraRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Carreira carreira)
        {
            try
            {
                var result = await carreiraRepo.Insert(carreira);
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
        public async Task<IActionResult> Put(int id,[FromBody] Carreira carreira)
        {
            try
            {
                if(carreira.Id != id)
                {
                    throw new Exception("Operação não pode ser realizada.");
                }

                var _carreira = await carreiraRepo.Select(id);

                if (_carreira.Id == 0)
                {
                    return NotFound(new Messages("Esta Carreira não existe ou já foi removido."));
                }

                await carreiraRepo.Update(carreira);
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
                var _carreira = await carreiraRepo.Select(id);

                if (_carreira.Id == 0)
                {
                    return NotFound("Esta Carreira não existe ou já foi removida.");
                }

                await carreiraRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new Messages(ex.Message));
            }
        }
    }
}
