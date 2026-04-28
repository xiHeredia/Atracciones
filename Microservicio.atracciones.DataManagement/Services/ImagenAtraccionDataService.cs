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

public class ImagenAtraccionDataService : IImagenAtraccionDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ImagenAtraccionDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ImagenAtraccionDataModel?> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ImagenAtraccionRepository.ObtenerAsync(atId, imgId, cancellationToken);
        return entity is null ? null : ImagenAtraccionDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<ImagenAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ImagenAtraccionRepository.ListarPorAtraccionAsync(atId, cancellationToken);
        return entities.Select(ImagenAtraccionDataMapper.ToModel).ToList();
    }

    public async Task<bool> CrearAsync(ImagenAtraccionDataModel model, CancellationToken cancellationToken = default)
    {
        var existente = await _unitOfWork.ImagenAtraccionRepository.ObtenerAsync(model.AtId, model.ImgId, cancellationToken);

        if (existente is not null)
            return true;

        var entity = new ImagenAtraccionEntity
        {
            AtId = model.AtId,
            ImgId = model.ImgId,
            ImaFechaIngreso = DateTimeOffset.UtcNow,
            ImaUsuarioIngreso = "api",
            ImaEstado = "A"
        };

        await _unitOfWork.ImagenAtraccionRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int imgId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ImagenAtraccionRepository.ObtenerAsync(atId, imgId, cancellationToken);

        if (entity is null)
            return false;

        entity.ImaEstado = "I";
        entity.ImaFechaEliminacion = DateTimeOffset.UtcNow;
        entity.ImaUsuarioEliminacion = "api";

        _unitOfWork.ImagenAtraccionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}