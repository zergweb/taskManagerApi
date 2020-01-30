using Infrastructure.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class TasksDto
    {
        public TaskTemplate Template { get; set; }
        public IEnumerable<TaskItem> Tasks { get; set; }
    }
}
