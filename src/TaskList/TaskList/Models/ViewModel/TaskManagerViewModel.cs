using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Commons.DTO
{
    public class TaskManagerViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TaskDate { get; set; }

        public string Status { get; set; }
    }
}
