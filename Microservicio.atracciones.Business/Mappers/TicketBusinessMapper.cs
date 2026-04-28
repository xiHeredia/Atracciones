using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Ticket;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class TicketBusinessMapper
{
    public static TicketDataModel ToDataModel(CrearTicketRequest request)
    {
        return new TicketDataModel
        {
            AtraccionId = request.AtraccionId,
            Titulo = request.Titulo,
            Precio = request.Precio,
            TipoParticipante = request.TipoParticipante,
            CapacidadMaxima = request.CapacidadMaxima,
            CuposDisponibles = request.CuposDisponibles
        };
    }

    public static TicketDataModel ToDataModel(ActualizarTicketRequest request)
    {
        return new TicketDataModel
        {
            Id = request.Id,
            AtraccionId = request.AtraccionId,
            Titulo = request.Titulo,
            Precio = request.Precio,
            TipoParticipante = request.TipoParticipante,
            CapacidadMaxima = request.CapacidadMaxima,
            CuposDisponibles = request.CuposDisponibles
        };
    }

    public static TicketResponse ToResponse(TicketDataModel model)
    {
        return new TicketResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            AtraccionId = model.AtraccionId,
            AtraccionNombre = model.AtraccionNombre,
            Titulo = model.Titulo,
            Precio = model.Precio,
            TipoParticipante = model.TipoParticipante,
            CapacidadMaxima = model.CapacidadMaxima,
            CuposDisponibles = model.CuposDisponibles
        };
    }
}