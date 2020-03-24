using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Interfaces
{
    public interface ICoreUserContext
    {
        Guid UserId { get; }
    }
}
