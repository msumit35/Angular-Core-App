using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class MasterEntityBase : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
