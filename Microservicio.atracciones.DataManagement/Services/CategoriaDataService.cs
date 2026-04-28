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

public class CategoriaDataService : ICategoriaDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoriaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoriaRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : CategoriaDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<CategoriaDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.CategoriaRepository.ListarAsync(cancellationToken);
        return entities.Select(CategoriaDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(CategoriaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new CategoriaEntity
        {
            CatGuid = Guid.NewGuid(),
            CatParentId = model.ParentId,
            CatNombre = model.Nombre,
            CatFechaIngreso = DateTimeOffset.UtcNow,
            CatUsuarioIngreso = "api",
            CatIpIngreso = "127.0.0.1",
            CatEstado = "A"
        };

        await _unitOfWork.CategoriaRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.CatId;
    }

    public async Task<bool> ActualizarAsync(CategoriaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoriaRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.CatNombre = model.Nombre;
        entity.CatParentId = model.ParentId;
        entity.CatFechaMod = DateTimeOffset.UtcNow;
        entity.CatUsuarioMod = "api";
        entity.CatIpMod = "127.0.0.1";

        _unitOfWork.CategoriaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoriaRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.CatEstado = "I";
        entity.CatFechaEliminacion = DateTimeOffset.UtcNow;
        entity.CatUsuarioEliminacion = "api";
        entity.CatIpEliminacion = "127.0.0.1";

        _unitOfWork.CategoriaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}