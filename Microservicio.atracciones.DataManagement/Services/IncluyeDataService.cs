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

public class IncluyeDataService : IIncluyeDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public IncluyeDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IncluyeDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IncluyeRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : IncluyeDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<IncluyeDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.IncluyeRepository.ListarAsync(cancellationToken);
        return entities.Select(IncluyeDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(IncluyeDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new IncluyeEntity
        {
            IncGuid = Guid.NewGuid(),
            IncDescripcion = model.Descripcion,
            IncEstado = "A"
        };

        await _unitOfWork.IncluyeRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.IncId;
    }

    public async Task<bool> ActualizarAsync(IncluyeDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IncluyeRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.IncDescripcion = model.Descripcion;

        _unitOfWork.IncluyeRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IncluyeRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.IncEstado = "I";

        _unitOfWork.IncluyeRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}