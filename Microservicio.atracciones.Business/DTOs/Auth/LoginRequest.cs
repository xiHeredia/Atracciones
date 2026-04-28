using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.atracciones.Business.DTOs.Auth;

public class LoginRequest
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}