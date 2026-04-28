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

public class ImagenRepository : IImagenRepository
{
    private readonly AtraccionesDbContext _context;

    public ImagenRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<ImagenEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Imagenes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ImgId == id && x.ImgEstado == "A", cancellationToken);
    }

    public async Task<ImagenEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Imagenes
            .FirstOrDefaultAsync(x => x.ImgId == id && x.ImgEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<ImagenEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Imagenes
            .AsNoTracking()
            .Where(x => x.ImgEstado == "A")
            .OrderBy(x => x.ImgId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ImagenEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Imagenes.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(ImagenEntity entity)
    {
        _context.Imagenes.Update(entity);
    }
}