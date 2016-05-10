using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }



        public Room() { }
        public Room(int id, string nm, string tp)
        {
            this.Id = id;
            this.Name = nm;
            this.Type = tp;
        }
        public virtual ICollection<Facility> RoomFacilieties { get; set; }
        public virtual ICollection<ExtraServices> RoomExtraServices { get; set; }
    }
}
