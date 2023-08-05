using Core.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.gameRoom
{
    public class gameRoom:IBaseEntity
    {
        public int gameRoomId { get; set; } 
        public string license { get; set; } 
        public int createdUserId { get; set; }       
        public virtual AppUser createdUser { get; set; }       
        public int winnerUserId { get; set; } 
        public virtual AppUser winnerUser { get; set; } 
        public DateTime endDate { get; set; }   
        public bool isDelete { get; set; }      
        public DateTime updateDate { get; set; }
        //public virtual ICollection<gameRoomUser> gameRoomUsers { get; set; }
        //public virtual ICollection<gameLog> gameLogs { get; set; }

    }



   
}
