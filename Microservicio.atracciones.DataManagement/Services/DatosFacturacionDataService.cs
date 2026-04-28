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

public class DatosFacturacionDataService : IDatosFacturacionDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public DatosFacturacionDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DatosFacturacionDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.DatosFacturacionRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : DatosFacturacionDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<DatosFacturacionDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.DatosFacturacionRepository.ListarAsync(cancellationToken);
        return entities.Select(DatosFacturacionDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(DatosFacturacionDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new DatosFacturacionEntity
        {
            DfacGuid = Guid.NewGuid(),
            FacId = model.FacturaId,
            DfacNombre = model.Nombre,
            DfacApellido = model.Apellido,
            DfacCorreo = model.Correo,
            DfacTelefono = model.Telefono
        };

        await _unitOfWork.DatosFacturacionRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.DfacId;
    }

    public async Task<bool> ActualizarAsync(DatosFacturacionDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.DatosFacturacionRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.FacId = model.FacturaId;
        entity.DfacNombre = model.Nombre;
        entity.DfacApellido = model.Apellido;
        entity.DfacCorreo = model.Correo;
        entity.DfacTelefono = model.Telefono;

        _unitOfWork.DatosFacturacionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}