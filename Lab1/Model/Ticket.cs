using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1 {
    class Ticket<Key> : IBase<Key> where Key : IComparable<Key> {
        public Key Id { get; set; }
        internal Ticket() {}
        public IList<int> SeatsOccupiedList {get {return _seatsOccupiedList; } internal set {
            foreach(int seat in value) _seatsOccupiedList.Add(seat);
        }}
        public int SeatsOccupied {get; set; }
        public int Adults {get; set; }
        public int Children {get; set; }
        public decimal Price {get; set; }
        public Flight<Key> Flight {get; set;}
        public Passenger<Key> Passenger {get; set; }
        private IList<int> _seatsOccupiedList = new List<int>();
        public override string ToString()
        {
            return "Passenger: " + Passenger + ", SeatsOccupied: " + SeatsOccupied + ", Adults: " + Adults + 
            ", Children: " + Children + ", Price: " + Price + ", Flight: " + Flight + ", SeatsOccupiedList: " + SeatsOccupiedList;
        }
    }
}
