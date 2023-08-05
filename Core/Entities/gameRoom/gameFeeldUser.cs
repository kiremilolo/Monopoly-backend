using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.gameRoom
{
    public class gameFeeldUser:IBaseEntity
    {
        public int gameFeeldUserId { get; set; }   
        public int userId { get; set; }   
        public virtual AppUser user { get; set; }   
        public int gameRoomId { get; set; }   
        public virtual gameRoom room { get; set; }   
        public string fieldName { get; set; }       
        public DateTime date { get; set; }      
    }
}
