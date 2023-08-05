using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.gameRoom
{
    public class gameLog : IBaseEntity
    {
        public int gameLogId { get; set; }
        public int userId { get; set; }
       public virtual AppUser user { get; set; }
        public int roomId { get; set; }
        public virtual  gameRoom room { get; set; }
        public int dice { get; set; }
        public int dice2 { get; set; }
        public int currentLocation { get; set; }
        public int endLocation { get; set; }
        public DateTime date { get; set; }
        public decimal wallet { get; set; }    
        public decimal spent { get; set; }      
    }
}
