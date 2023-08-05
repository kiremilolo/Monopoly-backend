using Core.Entities.Product;
using Core.Entities.Chat;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities.gameRoom;
using Core.Entities.Slider;
using Core.Entities.Task;

namespace Data
{
    public class MonopolyDbContext:IdentityDbContext
    {
        public MonopolyDbContext(DbContextOptions<MonopolyDbContext> opt):base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Core.Entities.AppUser> AppUsers { get; set; }    
        public DbSet<Classes> classes { get; set; }
        public DbSet<Chat> chat { get; set; }
        public DbSet<gameFeeldUser> gameFeeldUsers { get; set; }
        public DbSet<gameLog>  gameLogs { get; set; }
        public DbSet<gameRoom> gameRooms { get; set; }
        public DbSet<gameRoomUser> gameRoomUsers { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Core.Entities.Task.Task> tasks { get; set; } 
        public DbSet<UserTask> userTasks { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {

   //         builder.Entity<gameRoomUser>()
   // .HasOne(e => e.user)
   // .WithMany()
   // .OnDelete(DeleteBehavior.NoAction); // <--

   //         builder.Entity<gameRoomUser>()
   //.HasOne(e => e.gameRoom)
   //.WithMany()
   //.OnDelete(DeleteBehavior.NoAction); // <--



            base.OnModelCreating(builder);
        }


    }


    


    
}

