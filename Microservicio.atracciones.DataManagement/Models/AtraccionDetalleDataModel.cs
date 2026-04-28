using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class AtraccionDetalleDataModel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal PrecioReferencia { get; set; }
    public int DestinoId { get; set; }
    public string? DestinoNombre { get; set; }

    public IReadOnlyList<string> Idiomas { get; set; } = [];
    public IReadOnlyList<string> Incluye { get; set; } = [];
    public IReadOnlyList<string> Imagenes { get; set; } = [];
}