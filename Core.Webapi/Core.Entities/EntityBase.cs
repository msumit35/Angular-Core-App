using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
