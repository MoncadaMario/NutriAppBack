using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriAppBackEnd.Models;
[Table("consultas")]
public class Consulta
{
    [Key]
    [Column("id")]
    public int IdConsulta { get; set; } // Autoincremental

    [Column("edad")]
    [Required] // Asegura que el campo no sea nulo
    public int Edad { get; set; }

    [Column("altura")]
    [Required] // Asegura que el campo no sea nulo
    public float Altura { get; set; }

    [Column("peso")]
    [Required] // Asegura que el campo no sea nulo
    public float Peso { get; set; }

    [Column("grasa")]
    [Required] // Asegura que el campo no sea nulo
    public float Grasa { get; set; }

    [Column("fecha")]
    [Required] // Asegura que el campo no sea nulo
    public DateTime Fecha { get; set; }

    [Column("recomendacion")]
    [Required] // Asegura que el campo no sea nulo
    public string Recomendacion { get; set; }

    [Column("id_usuario")]
    [Required] // Asegura que el campo no sea nulo
    public int IdUsuario { get; set; } // Referencia a la tabla usuarios
}