using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Task
{
    public class Task : IBaseEntity
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }            
        public int Count { get; set; }
        public decimal Point { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
