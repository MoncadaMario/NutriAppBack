using NutriAppBackEnd.Models;
using NutriAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;


namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Datos de usuario inválidos");
            }
            var nuevoUsuario = await _usuarioService.CrearUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuarios), new { idUsuario = nuevoUsuario.IdUsuario }, nuevoUsuario);
        }

        [HttpPut("{idUsuario}")]
        public async Task<ActionResult> ActualizarUsuario(int idUsuario, [FromBody] Usuario usuarioActualizado)
        {
            if (usuarioActualizado == null)
            {
                return BadRequest("Datos de usuario inválidos");
            }

            var response = await _usuarioService.ActualizarUsuario(idUsuario, usuarioActualizado);

            if (!response)
            {
                return NotFound("Usuario no encontrado");
            }

            return NoContent();
        }

        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult> EliminarUsuario(int idUsuario)
        {
            var response = await _usuarioService.EliminarUsuario(idUsuario);
            if (!response)
            {
                return NotFound("Usuario no encontrado");
            }
            return NoContent();
        }
    }
}