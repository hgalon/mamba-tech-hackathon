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
    public class CursoController : ControllerBase
    {
        ICurso cursoRepo;
        private readonly ILogger<CursoController> _logger;

        public CursoController(ICurso cursoRepo, ILogger<CursoController> logger)
        {
            this.cursoRepo = cursoRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Curso>> Get()
        {
            return await cursoRepo.SelectAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Curso curso)
        {
            try
            {
                var result = await cursoRepo.Insert(curso);
                return StatusCode(201, new { message = "O Curso foi criado com sucesso!" , result });
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
        public async Task<IActionResult> Put(int id,[FromBody] Curso curso)
        {
            try
            {
                if(curso.Id != id)
                {
                    return NotFound(new { message = "Não encontrado" });
                }

                var _curso = await cursoRepo.Select(id);

                if (_curso.Id == 0)
                {
                    return NotFound(new { message = "Não encontrado" });
                }

                await cursoRepo.Update(curso);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
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
                var _curso = await cursoRepo.Select(id);

                if (_curso.Id == 0)
                {
                    return NotFound(new { message = "Não encontrado" });
                }

                await cursoRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
