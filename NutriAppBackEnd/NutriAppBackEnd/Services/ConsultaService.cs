using NutriAppBackEnd.Data;
using NutriAppBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace NutriAppBackEnd.Services;

public class ConsultaService
{
    private readonly DataContext _context;

    public ConsultaService(DataContext context)
    {
        _context = context;
    }

    //obtener todas las consultas
    public async Task<List<Consulta>> ObtenerConsultas()
    {
        return await _context.Consultas.ToListAsync();
    }

    //agregar consulta
    public async Task<Consulta> CrearConsulta(Consulta consulta, int idUsuario)
    {
        // Establecer el id_usuario para la consulta
        consulta.IdUsuario = idUsuario; // idUsuario debe ser un entero que corresponde al id del usuario

        // Agregar la consulta al contexto
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();

        return consulta;
    }

    //actualizar consulta
    public async Task<bool> ActualizarConsulta(int id, Consulta consultaActualizada)
    {
        // Buscar la consulta existente por su ID
        var consulta = await _context.Consultas.FindAsync(id);
        if (consulta == null) return false; // Si no se encuentra, retornar false

        // Actualizar las propiedades de la consulta
        consulta.Edad = consultaActualizada.Edad;
        consulta.Altura = consultaActualizada.Altura;
        consulta.Peso = consultaActualizada.Peso;
        consulta.Grasa = consultaActualizada.Grasa;
        consulta.Fecha = consultaActualizada.Fecha;
        consulta.Recomendacion = consultaActualizada.Recomendacion;
        consulta.IdUsuario = consultaActualizada.IdUsuario; // Si también deseas actualizar el id_usuario

        // Guardar los cambios en la base de datos
        await _context.SaveChangesAsync();
        return true; // Retornar true si la actualización fue exitosa
    }

    //eliminar consulta
    public async Task<bool> EliminarConsulta(int id)
    {
        // Buscar la consulta existente por su ID
        var consulta = await _context.Consultas.FindAsync(id);
        if (consulta == null) return false; // Si no se encuentra, retornar false

        // Eliminar la consulta del contexto
        _context.Consultas.Remove(consulta);
        await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
        return true; // Retornar true si la eliminación fue exitosa
    }
}