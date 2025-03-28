using NutriAppBackEnd.Models;
using NutriAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;


namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultasController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> ObtenerConsultas()
        {
            var consultas = await _consultaService.ObtenerConsultas();
            return Ok(consultas);
        }

        [HttpPost]
        public async Task<ActionResult> CrearConsulta([FromBody] Consulta consulta)
        {
            if (consulta == null)
            {
                return BadRequest("No hay consulta válida");
            }

            // Aquí no necesitas establecer idUsuario, ya que ya viene en el objeto consulta
            var nuevaConsulta = await _consultaService.CrearConsulta(consulta, consulta.IdUsuario);
            return CreatedAtAction(nameof(ObtenerConsultas), new { idConsulta = nuevaConsulta.IdConsulta }, nuevaConsulta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarConsulta(int id, [FromBody] Consulta consultaActualizada)
        {
            if (consultaActualizada == null)
            {
                return BadRequest("Consulta vacía");
            }

            var response = await _consultaService.ActualizarConsulta(id, consultaActualizada);

            if (!response)
            {
                return NotFound("Consulta no encontrada");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarConsulta(int id)
        {
            var response = await _consultaService.EliminarConsulta(id);
            if (!response)
            {
                return NotFound("Consulta no encontrada");
            }
            return NoContent();
        }
    }
}