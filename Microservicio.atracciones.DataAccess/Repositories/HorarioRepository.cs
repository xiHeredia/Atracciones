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

public class HorarioRepository : IHorarioRepository
{
    private readonly AtraccionesDbContext _context;

    public HorarioRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<HorarioEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Horarios
            .AsNoTracking()
            .Include(x => x.Ticket)
            .FirstOrDefaultAsync(x => x.HorId == id && x.HorEstado == "A", cancellationToken);
    }

    public async Task<HorarioEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Horarios
            .FirstOrDefaultAsync(x => x.HorId == id && x.HorEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<HorarioEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Horarios
            .AsNoTracking()
            .Include(x => x.Ticket)
            .Where(x => x.HorEstado == "A")
            .OrderBy(x => x.HorFecha)
            .ThenBy(x => x.HorHoraInicio)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(HorarioEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Horarios.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(HorarioEntity entity)
    {
        _context.Horarios.Update(entity);
    }
}