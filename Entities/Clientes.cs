using System.ComponentModel.DataAnnotations;

namespace WebEmpresa.Entities;

public class Clientes
{
    [Key]
    public int Id_cliente { get; set; }

    [Required]
    [StringLength(13)]
    public string? cui { get; set; }

    [Required]
    [StringLength(15)]
    public string? nit { get; set; }

    [Required]
    [StringLength(60)]
    public string? nombres { get; set; }

    [Required]
    [StringLength(60)]
    public string? apellidos { get; set; }

    [StringLength(150)]
    public string? direccion { get; set; }

    [StringLength(12)]
    public string? telefono { get; set; }

    [Required]
    public DateTime fecha_nacimiento { get; set; }
}