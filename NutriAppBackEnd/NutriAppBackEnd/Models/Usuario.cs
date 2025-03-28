using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriAppBackEnd.Models;
[Table("usuarios")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; } // Cambiado a int para autoincremento

    [Column("nombre")]
    [Required] // Asegura que el campo no sea nulo
    public string Nombre { get; set; }

    [Column("correo")]
    [Required] // Asegura que el campo no sea nulo
    [EmailAddress] // Valida que el formato del correo sea correcto
    public string Correo { get; set; }

    [Column("contrasena")]
    [Required] // Asegura que el campo no sea nulo
    public string Contrasena { get; set; }

    [Column("rol")]
    [Required] // Asegura que el campo no sea nulo
    public string Rol { get; set; }

    [Column("genero")]
    public string Genero { get; set; }
}