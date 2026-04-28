using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.atracciones.Business.DTOs.Auth;

public class LoginResponse
{
    public string UserName { get; set; } = null!;
    public IReadOnlyCollection<string> Roles { get; set; } = Array.Empty<string>();
    public string? Token { get; set; }
    public DateTime? ExpirationUtc { get; set; }
}