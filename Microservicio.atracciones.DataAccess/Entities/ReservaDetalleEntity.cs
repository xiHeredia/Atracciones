using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ReservaDetalleEntity
{
    public int RdetId { get; set; }
    public Guid RdetGuid { get; set; }

    public int RevId { get; set; }
    public int TckId { get; set; }

    public int RdetCantidad { get; set; }
    public decimal RdetPrecioUnit { get; set; }
    public decimal RdetSubtotal { get; set; }

    public DateTimeOffset RdetFechaIngreso { get; set; }
    public string RdetUsuarioIngreso { get; set; } = null!;
    public string RdetIpIngreso { get; set; } = null!;

    public DateTimeOffset? RdetFechaEliminacion { get; set; }
    public string? RdetUsuarioEliminacion { get; set; }
    public string? RdetIpEliminacion { get; set; }

    public string RdetEstado { get; set; } = "A";

    public ReservaEntity Reserva { get; set; } = null!;
    public TicketEntity Ticket { get; set; } = null!;
}