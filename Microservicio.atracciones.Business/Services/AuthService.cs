using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Auth;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            throw new ValidationException("El nombre de usuario es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ValidationException("La contraseña es obligatoria.");

        var usuario = await _unitOfWork.UsuarioRepository.ObtenerPorLoginAsync(request.UserName, cancellationToken);

        if (usuario is null)
            throw new UnauthorizedBusinessException("Usuario o contraseña inválidos.");

        if (usuario.UsuPasswordHash != request.Password)
            throw new UnauthorizedBusinessException("Usuario o contraseña inválidos.");

        return new LoginResponse
        {
            UsuarioId = usuario.UsuId,
            UserName = usuario.UsuLogin,
            Roles = usuario.UsuarioRoles
                .Select(x => x.Rol.RolDescripcion)
                .Distinct()
                .ToList()
        };
    }
}
