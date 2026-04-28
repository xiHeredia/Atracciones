using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;

public class CrearCategoriaAtraccionRequest
{
    public int AtId { get; set; }
    public int CatId { get; set; }
}
