using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.gameRoom
{
    public class gameRoomUser:IBaseEntity
    {
        public int gameRoomUserId { get; set; }    
        public int gameRoomId { get; set; }    
        public virtual gameRoom gameRoom { get; set; }  
        public int userId { get; set; } 
        public virtual AppUser user { get; set; }        
    }
}
