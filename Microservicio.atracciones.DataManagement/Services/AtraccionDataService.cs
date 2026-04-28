using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Mappers;
using Microservicio.atracciones.DataManagement.Models;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataManagement.Services;

public class AtraccionDataService : IAtraccionDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public AtraccionDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AtraccionDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AtraccionRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity == null ? null : AtraccionDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<AtraccionDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AtraccionRepository.ListarAsync(cancellationToken);
        return entities.Select(AtraccionDataMapper.ToModel).ToList();
    }

    public async Task<IReadOnlyList<AtraccionDataModel>> BuscarAsync(AtraccionFiltroDataModel filtro, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AtraccionQueryRepository
            .BuscarAsync(filtro.Nombre, filtro.DestinoId, cancellationToken);

        return entities.Select(AtraccionDataMapper.ToModel).ToList();
    }
    public async Task<int> CrearAsync(AtraccionDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new AtraccionEntity
        {
            AtGuid = Guid.NewGuid(),
            DesId = model.DestinoId,
            AtNombre = model.Nombre,
            AtDescripcion = model.Descripcion,
            AtTotalResenias = 0,
            AtPrecioReferencia = model.Precio,
            AtIncluyeAcompaniante = false,
            AtIncluyeTransporte = false,
            AtDisponible = true,
            AtFechaIngreso = DateTimeOffset.UtcNow,
            AtUsuarioIngreso = "api",
            AtIpIngreso = "127.0.0.1",
            AtEstado = "A"
        };

        await _unitOfWork.AtraccionRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.AtId;
    }
    public async Task<bool> ActualizarAsync(AtraccionDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AtraccionRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.DesId = model.DestinoId;
        entity.AtNombre = model.Nombre;
        entity.AtDescripcion = model.Descripcion;
        entity.AtPrecioReferencia = model.Precio;
        entity.AtFechaMod = DateTimeOffset.UtcNow;
        entity.AtUsuarioMod = "api";
        entity.AtIpMod = "127.0.0.1";

        _unitOfWork.AtraccionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AtraccionRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.AtEstado = "I";
        entity.AtFechaEliminacion = DateTimeOffset.UtcNow;

        _unitOfWork.AtraccionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<AtraccionDetalleDataModel?> ObtenerDetalleAsync(int id, CancellationToken cancellationToken = default)
    {
        var atraccion = await _unitOfWork.AtraccionRepository.ObtenerPorIdAsync(id, cancellationToken);

        if (atraccion is null)
            return null;

        var idiomas = await _unitOfWork.IdiomaAtraccionRepository.ListarPorAtraccionAsync(id, cancellationToken);
        var incluye = await _unitOfWork.AtraccionIncluyeRepository.ListarPorAtraccionAsync(id, cancellationToken);
        var imagenes = await _unitOfWork.ImagenAtraccionRepository.ListarPorAtraccionAsync(id, cancellationToken);

        return new AtraccionDetalleDataModel
        {
            Id = atraccion.AtId,
            Nombre = atraccion.AtNombre,
            Descripcion = atraccion.AtDescripcion,
            PrecioReferencia = atraccion.AtPrecioReferencia ?? 0,
            DestinoId = atraccion.DesId,
            DestinoNombre = atraccion.Destino?.DesNombre,

            Idiomas = idiomas
                .Select(x => x.Idioma?.IdiDescripcion)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .ToList(),

            Incluye = incluye
                .Select(x => x.Incluye?.IncDescripcion)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .ToList(),

            Imagenes = imagenes
                .Select(x => x.Imagen?.ImgUrl)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .ToList()
        };
    }
}