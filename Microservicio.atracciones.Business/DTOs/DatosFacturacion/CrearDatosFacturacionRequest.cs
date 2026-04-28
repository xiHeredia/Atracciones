using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.DatosFacturacion;

public class CrearDatosFacturacionRequest
{
    public int FacturaId { get; set; }

    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Telefono { get; set; }
}