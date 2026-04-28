using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class ReservaDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Codigo { get; set; } = null!;

    public int ClienteId { get; set; }
    public int HorarioId { get; set; }

    public DateTimeOffset FechaReservaUtc { get; set; }

    public decimal Subtotal { get; set; }
    public decimal ValorIva { get; set; }
    public decimal Total { get; set; }

    public string OrigenCanal { get; set; } = null!;
    public string Estado { get; set; } = null!;
}
