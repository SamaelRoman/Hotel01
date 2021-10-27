using Hotel01.DAL.Etities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel01.DAL.Ef
{
    public class ContextDB : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryInfo> CategoryInfos { get; set; }
        public DbSet<service> Services { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingInfo> BookingInfos { get; set; }
        public ContextDB(string ConnectionString):base(ConnectionString)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}