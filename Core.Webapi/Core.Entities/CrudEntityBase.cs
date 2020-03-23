using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class CrudEntityBase : CreateEntityBase
    {
        public DateTimeOffset? LastUpdatedOn { get; set; }

        public DateTimeOffset? RemovedOn { get; set; }
    }
}
