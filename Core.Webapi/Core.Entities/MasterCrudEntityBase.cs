using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MasterCrudEntityBase : CrudEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
