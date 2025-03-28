using NutriAppBackEnd.Data;
using NutriAppBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace NutriAppBackEnd.Services;

public class UsuarioService
{
    private readonly DataContext _context;

    public UsuarioService(DataContext context)
    {
        _context = context;
    }

    //obtener todos los usuarios
    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    //crear un usuario 
    public async Task<Usuario> CrearUsuario(Usuario usuario)
    {
        // No es necesario establecer IdUsuario, ya que es autoincremental
        // usuario.IdUsuario = Guid.NewGuid(); // Esta línea se elimina

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario; // Retorna el usuario creado, que ahora tendrá el IdUsuario asignado automáticamente
    }

    //actualizar un usuario
    public async Task<bool> ActualizarUsuario(int idUsuario, Usuario usuarioActualizado)
    {
        // Buscar el usuario existente por su ID
        var usuario = await _context.Usuarios.FindAsync(idUsuario);
        if (usuario == null) return false; // Si no se encuentra, retornar false

        // Actualizar las propiedades del usuario
        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Contrasena = usuarioActualizado.Contrasena;
        usuario.Correo = usuarioActualizado.Correo;
        usuario.Rol = usuarioActualizado.Rol; // Si deseas actualizar el rol
        usuario.Genero = usuarioActualizado.Genero; // Si deseas actualizar el género

        // Guardar los cambios en la base de datos
        await _context.SaveChangesAsync();
        return true; // Retornar true si la actualización fue exitosa
    }

    //eliminar un usuario
    public async Task<bool> EliminarUsuario(int idUsuario)
    {
        // Buscar el usuario existente por su ID
        var usuario = await _context.Usuarios.FindAsync(idUsuario);
        if (usuario == null) return false; // Si no se encuentra, retornar false

        // Eliminar el usuario del contexto
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
        return true; // Retornar true si la eliminación fue exitosa
    }
}