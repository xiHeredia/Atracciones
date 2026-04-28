using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Factura;

public class InhabilitarFacturaRequest
{
    public string Motivo { get; set; } = null!;
}