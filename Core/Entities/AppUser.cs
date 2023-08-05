using Core.Entities.gameRoom;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Entities
{
    public class AppUser:IdentityUser
    {
        public int AppUserId { get; set; }  
        public string ImgUrl { get; set; }                  
        public string Name { get; set; }
        public decimal Balance { get; set; } 
        public bool IsAdmin { get; set; }   
        public bool IsDelete { get; set; }  
        public DateTime updateDate { get; set; }
        
        //public ICollection<gameRoomUser> gameRoomUsers { get; set; }    

    } 
}
