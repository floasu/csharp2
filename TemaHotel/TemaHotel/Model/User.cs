using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.Model
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String UserType { get; set; }
        public bool Active { get; set; }


        public User() {}
        public User(string username, string name, string email, string usertp)
        {
            this.Username = username;
            this.Name = name;
            this.Email = email;
            this.UserType = usertp;
            this.Active = true;

        }

        public User(string username, string name, string email)
        {
            this.Username = username;
            this.Name = name;
            this.Email = email;
            this.UserType = (String)Enum.Parse(typeof(UserType), "Client"); 
            this.Active = true;

        }
    }
}
