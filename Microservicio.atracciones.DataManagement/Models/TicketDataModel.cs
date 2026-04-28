using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class TicketDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int AtraccionId { get; set; }
    public string? AtraccionNombre { get; set; }

    public string Titulo { get; set; } = null!;
    public decimal Precio { get; set; }
    public string TipoParticipante { get; set; } = null!;
    public int CapacidadMaxima { get; set; }
    public int CuposDisponibles { get; set; }
}