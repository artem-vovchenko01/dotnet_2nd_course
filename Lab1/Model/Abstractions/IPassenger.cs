using System.Collections.Generic;
using System;

namespace Lab1 
{
    interface IPassenger<Key> : IBase<Key> {
        string Name {get; set;}
        string Surname {get; set; }
        long Passport {get; set; }
        int Age {get; set; }
    }
}
