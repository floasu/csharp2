using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class FriendContext : DbContext
    {
        public DbSet<Facility> AvailableFacilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<ExtraServices> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        public FriendContext()
            : base("myConnectionString")
        { }


    }

    public class MasterContextInitializer : DropCreateDatabaseIfModelChanges<FriendContext>
    {

    }

}
