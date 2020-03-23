using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class CreateEntityBase : EntityBase
    {
        protected CreateEntityBase()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
