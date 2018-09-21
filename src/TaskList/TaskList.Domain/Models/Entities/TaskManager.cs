using System;
using TaskList.Domain.Base;
using TaskList.Domain.Commons.Enums;

namespace TaskList.Domain.Models.Entities
{

    public partial class TaskManager : GenericEntity<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TaskDate { get; set; }

        public StatusTask Status { get; set; }
    }
}
