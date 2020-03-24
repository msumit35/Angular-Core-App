using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class CreateEntityBase : EntityBase
    {
        protected CreateEntityBase()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public Guid CreatedById { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        [ForeignKey("CreatedById")]
        public User User { get; set; }
    }
}
