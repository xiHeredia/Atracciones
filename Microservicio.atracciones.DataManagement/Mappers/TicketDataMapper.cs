using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class TicketDataMapper
{
    public static TicketDataModel ToModel(TicketEntity entity)
    {
        return new TicketDataModel
        {
            Id = entity.TckId,
            Guid = entity.TckGuid,
            AtraccionId = entity.AtId,
            AtraccionNombre = entity.Atraccion?.AtNombre,
            Titulo = entity.TckTitulo,
            Precio = entity.TckPrecio,
            TipoParticipante = entity.TckTipoParticipante,
            CapacidadMaxima = entity.TckCapacidadMaxima,
            CuposDisponibles = entity.TckCuposDisponibles
        };
    }
}