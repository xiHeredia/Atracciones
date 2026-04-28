using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Services;
using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Services;

namespace Microservicio.atracciones.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AtraccionesDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AtraccionesDb")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAtraccionDataService, AtraccionDataService>();
        services.AddScoped<IDestinoDataService, DestinoDataService>();
        services.AddScoped<ICategoriaDataService, CategoriaDataService>();
        services.AddScoped<IIdiomaDataService, IdiomaDataService>();
        services.AddScoped<IIncluyeDataService, IncluyeDataService>();
        services.AddScoped<IAtraccionIncluyeDataService, AtraccionIncluyeDataService>();
        services.AddScoped<IImagenDataService, ImagenDataService>();
        services.AddScoped<IImagenAtraccionDataService, ImagenAtraccionDataService>();
        services.AddScoped<IIdiomaAtraccionDataService, IdiomaAtraccionDataService>();
        services.AddScoped<ICategoriaAtraccionDataService, CategoriaAtraccionDataService>();
        services.AddScoped<ITicketDataService, TicketDataService>();
        services.AddScoped<IClienteDataService, ClienteDataService>();
        services.AddScoped<IHorarioDataService, HorarioDataService>();
        services.AddScoped<IReservaDataService, ReservaDataService>();
        services.AddScoped<IReservaDetalleDataService, ReservaDetalleDataService>();
        services.AddScoped<IReseniaDataService, ReseniaDataService>();
        services.AddScoped<IFacturaDataService, FacturaDataService>();
        services.AddScoped<IDatosFacturacionDataService, DatosFacturacionDataService>();
        services.AddScoped<IUsuarioDataService, UsuarioDataService>();
        services.AddScoped<IRolDataService, RolDataService>();
        services.AddScoped<IUsuarioRolDataService, UsuarioRolDataService>();

        services.AddScoped<IAtraccionService, AtraccionService>();
        services.AddScoped<IDestinoService, DestinoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IIdiomaService, IdiomaService>();
        services.AddScoped<IIncluyeService, IncluyeService>();
        services.AddScoped<IAtraccionIncluyeService, AtraccionIncluyeService>();
        services.AddScoped<IImagenService, ImagenService>();
        services.AddScoped<IImagenAtraccionService, ImagenAtraccionService>();
        services.AddScoped<IIdiomaAtraccionService, IdiomaAtraccionService>();
        services.AddScoped<ICategoriaAtraccionService, CategoriaAtraccionService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IHorarioService, HorarioService>();
        services.AddScoped<IReservaService, ReservaService>();
        services.AddScoped<IReservaDetalleService, ReservaDetalleService>();
        services.AddScoped<IReservaCompletaService, ReservaCompletaService>();
        services.AddScoped<IReseniaService, ReseniaService>();
        services.AddScoped<IFacturaService, FacturaService>();
        services.AddScoped<IDatosFacturacionService, DatosFacturacionService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IRolService, RolService>();
        services.AddScoped<IUsuarioRolService, UsuarioRolService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}