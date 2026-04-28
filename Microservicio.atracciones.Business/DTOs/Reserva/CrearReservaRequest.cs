using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Reserva;

public class CrearReservaRequest
{
    public int ClienteId { get; set; }
    public int HorarioId { get; set; }

    public decimal Subtotal { get; set; }
    public decimal ValorIva { get; set; }
    public decimal Total { get; set; }

    public string OrigenCanal { get; set; } = null!;
}