using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Slider
{
    public class Slider:IBaseEntity
    {
        public int SliderId { get; set; }      
        public string imgUrl { get; set; }      
        public DateTime updateDate { get; set; }
        public bool posterStatus { get; set; }  
        public bool isDelete { get; set; }  
    }
}
