using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Mappers;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Services;

public class DestinoDataService : IDestinoDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public DestinoDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DestinoDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.DestinoRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : DestinoDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<DestinoDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.DestinoRepository.ListarAsync(cancellationToken);
        return entities.Select(DestinoDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(DestinoDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new DestinoEntity
        {
            DesGuid = Guid.NewGuid(),
            DesNombre = model.Nombre,
            DesPais = model.Pais,
            DesImagenUrl = model.ImagenUrl,
            DesFechaIngreso = DateTimeOffset.UtcNow,
            DesUsuarioIngreso = "api",
            DesIpIngreso = "127.0.0.1",
            DesEstado = "A"
        };

        await _unitOfWork.DestinoRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.DesId;
    }

    public async Task<bool> ActualizarAsync(DestinoDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.DestinoRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.DesNombre = model.Nombre;
        entity.DesPais = model.Pais;
        entity.DesImagenUrl = model.ImagenUrl;
        entity.DesFechaMod = DateTimeOffset.UtcNow;
        entity.DesUsuarioMod = "api";
        entity.DesIpMod = "127.0.0.1";

        _unitOfWork.DestinoRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.DestinoRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.DesEstado = "I";
        entity.DesFechaEliminacion = DateTimeOffset.UtcNow;
        entity.DesUsuarioEliminacion = "api";
        entity.DesIpEliminacion = "127.0.0.1";

        _unitOfWork.DestinoRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}