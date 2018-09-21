using TaskList.Domain.Interfaces.Generics;
using System;

namespace TaskList.Domain.Base
{
    public class GenericEntity<TId> : IGenericEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }

    }
}
