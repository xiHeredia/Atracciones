using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.atracciones.Business.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}
