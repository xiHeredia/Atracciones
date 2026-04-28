using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microservicio.atracciones.Business.DTOs.ReservaCompleta;

public class CrearReservaCompletaRequest
{
    public int ClienteId { get; set; }
    public int HorarioId { get; set; }
    public string OrigenCanal { get; set; } = "WEB";
    public List<CrearReservaCompletaItemRequest> Items { get; set; } = new();
}

public class CrearReservaCompletaItemRequest
{
    public int TicketId { get; set; }
    public int Cantidad { get; set; }
}