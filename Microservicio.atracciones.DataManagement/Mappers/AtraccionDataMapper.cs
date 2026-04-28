using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class AtraccionDataMapper
{
    public static AtraccionDataModel ToModel(AtraccionEntity entity)
    {
        return new AtraccionDataModel
        {
            Id = entity.AtId,
            Nombre = entity.AtNombre,
            Descripcion = entity.AtDescripcion,
            Precio = entity.AtPrecioReferencia,
            DestinoId = entity.DesId,
            DestinoNombre = entity.Destino?.DesNombre ?? string.Empty
        };
    }
}