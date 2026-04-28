using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataAccess.Repositories.Interfaces;

namespace Microservicio.atracciones.DataAccess.Repositories;

public class DatosFacturacionRepository : IDatosFacturacionRepository
{
    private readonly AtraccionesDbContext _context;

    public DatosFacturacionRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<DatosFacturacionEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.DatosFacturacion
            .AsNoTracking()
            .Include(x => x.Factura)
            .FirstOrDefaultAsync(x => x.DfacId == id, cancellationToken);
    }

    public async Task<DatosFacturacionEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.DatosFacturacion
            .FirstOrDefaultAsync(x => x.DfacId == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DatosFacturacionEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.DatosFacturacion
            .AsNoTracking()
            .Include(x => x.Factura)
            .OrderBy(x => x.DfacId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(DatosFacturacionEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.DatosFacturacion.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(DatosFacturacionEntity entity)
    {
        _context.DatosFacturacion.Update(entity);
    }
}