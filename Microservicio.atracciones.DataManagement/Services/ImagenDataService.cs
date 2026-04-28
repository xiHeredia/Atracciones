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

public class ImagenDataService : IImagenDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ImagenDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ImagenDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ImagenRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : ImagenDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<ImagenDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ImagenRepository.ListarAsync(cancellationToken);
        return entities.Select(ImagenDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(ImagenDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new ImagenEntity
        {
            ImgGuid = Guid.NewGuid(),
            ImgUrl = model.Url,
            ImgDescripcion = model.Descripcion,
            ImgFechaIngreso = DateTimeOffset.UtcNow,
            ImgUsuarioIngreso = "api",
            ImgIpIngreso = "127.0.0.1",
            ImgEstado = "A"
        };

        await _unitOfWork.ImagenRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ImgId;
    }

    public async Task<bool> ActualizarAsync(ImagenDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ImagenRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.ImgUrl = model.Url;
        entity.ImgDescripcion = model.Descripcion;
        entity.ImgFechaMod = DateTimeOffset.UtcNow;
        entity.ImgUsuarioMod = "api";
        entity.ImgIpMod = "127.0.0.1";

        _unitOfWork.ImagenRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ImagenRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.ImgEstado = "I";
        entity.ImgFechaEliminacion = DateTimeOffset.UtcNow;
        entity.ImgUsuarioEliminacion = "api";
        entity.ImgIpEliminacion = "127.0.0.1";

        _unitOfWork.ImagenRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}