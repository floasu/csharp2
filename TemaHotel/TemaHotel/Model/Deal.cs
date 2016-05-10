using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.Model
{
    public class Deal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NightsNr { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool Active { get; set; }
    }
}
