using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.ReservaDetalle;

public class ReservaDetalleResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int ReservaId { get; set; }
    public int TicketId { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}