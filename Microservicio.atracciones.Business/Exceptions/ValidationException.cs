using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.Exceptions;

public class ValidationException : BusinessException
{
    public IReadOnlyCollection<string> Errors { get; }

    public ValidationException(string message, IReadOnlyCollection<string>? errors = null)
        : base(message)
    {
        Errors = errors ?? Array.Empty<string>();
    }
}