using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Categoria;

namespace Microservicio.atracciones.Business.Validators;

public static class CategoriaValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearCategoriaRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre de la categoría es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarCategoriaRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la categoría es inválido.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre de la categoría es obligatorio.");

        return errors;
    }
}