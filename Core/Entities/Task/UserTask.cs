using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Task
{
    public class UserTask:IBaseEntity
    {
        public int UserTaskId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }      
        public decimal Point { get; set; }
        public decimal MaxPoint { get; set; }
        public bool IsDelete { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
