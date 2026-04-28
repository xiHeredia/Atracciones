using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.ReservaCompleta;

public class ReservaCompletaResponse
{
    public int ReservaId { get; set; }
    public string Codigo { get; set; } = null!;
    public decimal Subtotal { get; set; }
    public decimal ValorIva { get; set; }
    public decimal Total { get; set; }
}