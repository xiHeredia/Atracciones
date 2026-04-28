using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Ticket;

public class ActualizarTicketRequest
{
    public int Id { get; set; }
    public int AtraccionId { get; set; }
    public string Titulo { get; set; } = null!;
    public decimal Precio { get; set; }
    public string TipoParticipante { get; set; } = null!;
    public int CapacidadMaxima { get; set; }
    public int CuposDisponibles { get; set; }
}