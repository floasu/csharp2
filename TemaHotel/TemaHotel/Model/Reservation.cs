using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public User CustomerUser { get; set; }
        public Room ReservedRoom { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NightNr { get; set; }
        public double Price { get; set; }
        public String Status { get; set; }
        public bool Active { get; set; }

        public Reservation()
        {
            Active = true;
            Status = "WaitingPayment";
        }


    }
}
