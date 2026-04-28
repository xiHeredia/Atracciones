using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Horario;

public class HorarioResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int TicketId { get; set; }
    public string? TicketTitulo { get; set; }

    public DateOnly Fecha { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public int CuposDisponibles { get; set; }
}