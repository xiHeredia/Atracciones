using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Resenia;

public class ReseniaResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int AtraccionId { get; set; }
    public int ReservaId { get; set; }

    public string Comentario { get; set; } = null!;
    public short Rating { get; set; }
}