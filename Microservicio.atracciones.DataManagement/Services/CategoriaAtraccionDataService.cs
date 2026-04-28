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

public class CategoriaAtraccionDataService : ICategoriaAtraccionDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaAtraccionDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoriaAtraccionDataModel?> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoriaAtraccionRepository.ObtenerAsync(atId, catId, cancellationToken);
        return entity is null ? null : CategoriaAtraccionDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<CategoriaAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.CategoriaAtraccionRepository.ListarPorAtraccionAsync(atId, cancellationToken);
        return entities.Select(CategoriaAtraccionDataMapper.ToModel).ToList();
    }

    public async Task<bool> CrearAsync(CategoriaAtraccionDataModel model, CancellationToken cancellationToken = default)
    {
        var existente = await _unitOfWork.CategoriaAtraccionRepository.ObtenerAsync(model.AtId, model.CatId, cancellationToken);

        if (existente is not null)
            return true;

        var entity = new CategoriaAtraccionEntity
        {
            AtId = model.AtId,
            CatId = model.CatId,
            CaFechaIngreso = DateTimeOffset.UtcNow,
            CaUsuarioIngreso = "api",
            CaEstado = "A"
        };

        await _unitOfWork.CategoriaAtraccionRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int catId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoriaAtraccionRepository.ObtenerAsync(atId, catId, cancellationToken);

        if (entity is null)
            return false;

        entity.CaEstado = "I";
        entity.CaFechaEliminacion = DateTimeOffset.UtcNow;
        entity.CaUsuarioEliminacion = "api";

        _unitOfWork.CategoriaAtraccionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}