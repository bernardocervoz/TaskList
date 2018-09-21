
using System;

namespace TaskList.Domain.Interfaces.Generics
{
    public interface IGenericEntity<TId>
    {
        TId Id { get; set; }
        bool Deleted { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
