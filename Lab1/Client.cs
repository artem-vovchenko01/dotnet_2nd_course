using System.Collections.Generic;

namespace Lab1 
{
    class Client {
        public static List<Client> Clients = new List<Client>();
        public string Name {get; set;}
        public string Surname {get; set; }
        public long Passport {get; set; }
        public int Age {get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}