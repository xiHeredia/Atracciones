using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.DatosFacturacion;

namespace Microservicio.atracciones.Business.Validators;

public static class DatosFacturacionValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearDatosFacturacionRequest request)
    {
        var errors = new List<string>();

        if (request.FacturaId <= 0)
            errors.Add("El id de la factura es inválido.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Apellido))
            errors.Add("El apellido es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Correo))
            errors.Add("El correo es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarDatosFacturacionRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de los datos de facturación es inválido.");

        if (request.FacturaId <= 0)
            errors.Add("El id de la factura es inválido.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Apellido))
            errors.Add("El apellido es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Correo))
            errors.Add("El correo es obligatorio.");

        return errors;
    }
}