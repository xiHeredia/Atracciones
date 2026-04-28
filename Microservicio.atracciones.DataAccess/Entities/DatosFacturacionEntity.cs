using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class DatosFacturacionEntity
{
    public int DfacId { get; set; }
    public Guid DfacGuid { get; set; }

    public int FacId { get; set; }

    public string DfacNombre { get; set; } = null!;
    public string DfacApellido { get; set; } = null!;
    public string DfacCorreo { get; set; } = null!;
    public string? DfacTelefono { get; set; }

    public FacturaEntity Factura { get; set; } = null!;
}