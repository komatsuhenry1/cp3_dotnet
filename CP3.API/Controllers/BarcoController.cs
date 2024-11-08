using CP3.Application.Dtos;
using CP3.Application.Services;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcoController : ControllerBase
    {
        private readonly IBarcoApplicationService _barcoService;

        public BarcoController(IBarcoApplicationService barcoService)
        {
            _barcoService = barcoService;
        }

        [HttpGet]
        public IActionResult ObterTodosBarcos()
        {
            var barcos = _barcoService.ObterTodosBarcos();
            return Ok(barcos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterBarcoPorId(int id)
        {
            var barco = _barcoService.ObterBarcoPorId(id);
            if (barco == null)
                return NotFound();

            return Ok(barco);
        }

        [HttpPost]
        public IActionResult AdicionarBarco([FromBody] BarcoDto barcoDto)
        {
            if (barcoDto == null || !barcoDto.Validate())
                return BadRequest("Dados inválidos");

            var barco = _barcoService.AdicionarBarco(barcoDto);
            return CreatedAtAction(nameof(ObterBarcoPorId), new { id = barco.Id }, barco);
        }

        [HttpPut("{id}")]
        public IActionResult EditarBarco(int id, [FromBody] BarcoDto barcoDto)
        {
            if (barcoDto == null || !barcoDto.Validate())
                return BadRequest("Dados inválidos");

            var barco = _barcoService.EditarBarco(id, barcoDto);
            if (barco == null)
                return NotFound();

            return Ok(barco);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverBarco(int id)
        {
            var barco = _barcoService.RemoverBarco(id);
            if (barco == null)
                return NotFound();

            return Ok(barco);
        }
    }
}
