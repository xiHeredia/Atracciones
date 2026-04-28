using Microservicio.atracciones.Business.DTOs.Auth;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}