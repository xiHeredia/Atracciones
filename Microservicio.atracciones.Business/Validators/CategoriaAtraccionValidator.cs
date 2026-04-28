using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;

namespace Microservicio.atracciones.Business.Validators;

public static class CategoriaAtraccionValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearCategoriaAtraccionRequest request)
    {
        var errors = new List<string>();

        if (request.AtId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.CatId <= 0)
            errors.Add("El id de la categoría es inválido.");

        return errors;
    }
}
