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

public class ImagenAtraccionRepository : IImagenAtraccionRepository
{
    private readonly AtraccionesDbContext _context;

    public ImagenAtraccionRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<ImagenAtraccionEntity?> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default)
    {
        return await _context.ImagenesAtraccion
            .Include(x => x.Imagen)
            .Include(x => x.Atraccion)
            .FirstOrDefaultAsync(
                x => x.AtId == atId && x.ImgId == imgId && x.ImaEstado == "A",
                cancellationToken);
    }

    public async Task<IReadOnlyList<ImagenAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        return await _context.ImagenesAtraccion
            .AsNoTracking()
            .Include(x => x.Imagen)
            .Where(x => x.AtId == atId && x.ImaEstado == "A")
            .OrderBy(x => x.ImgId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ImagenAtraccionEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.ImagenesAtraccion.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(ImagenAtraccionEntity entity)
    {
        _context.ImagenesAtraccion.Update(entity);
    }
}