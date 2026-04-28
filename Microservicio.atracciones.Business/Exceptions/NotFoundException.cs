using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.atracciones.Business.Exceptions;

public class NotFoundException : BusinessException
{
    public NotFoundException(string message) : base(message)
    {
    }
}