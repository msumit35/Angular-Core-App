using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Webapi.Enums
{
    public enum ResponseStatus
    {
        Success = 200,
        UserNotExist = 100,
        UsernamePasswordNotMatch = 404,
        UserAlreadyExists = 300,
        InternalServerError = 500,
        AccountDeactivated = 600
    }
}
