using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class CrudEntityBase : EntityBase
    {
        protected CrudEntityBase()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastUpdatedOn { get; set; }
        public DateTimeOffset? RemovedOn { get; set; }
    }
}
