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

public class RolDataService : IRolDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public RolDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RolDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.RolRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : RolDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<RolDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.RolRepository.ListarAsync(cancellationToken);
        return entities.Select(RolDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(RolDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new RolEntity
        {
            RolGuid = Guid.NewGuid(),
            RolDescripcion = model.Descripcion,
            RolFechaIngreso = DateTimeOffset.UtcNow,
            RolUsuarioIngreso = "api",
            RolIpIngreso = "127.0.0.1",
            RolEstado = "A"
        };

        await _unitOfWork.RolRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.RolId;
    }

    public async Task<bool> ActualizarAsync(RolDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.RolRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.RolDescripcion = model.Descripcion;

        _unitOfWork.RolRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.RolRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.RolEstado = "I";
        entity.RolFechaEliminacion = DateTimeOffset.UtcNow;
        entity.RolUsuarioEliminacion = "api";
        entity.RolIpEliminacion = "127.0.0.1";

        _unitOfWork.RolRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}