using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Chat
{
    public class Chat:IBaseEntity
    {
        public int ChatId { get; set; }    
        public string chatText { get; set; }    
        public string user { get; set; }        
        public DateTime date { get; set; }  
    }
}
