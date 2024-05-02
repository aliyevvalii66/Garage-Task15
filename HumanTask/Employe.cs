using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTask
{
    public class Employe : Human
    {
        public string Position { get; set; }
        public Employe(string name ,string surname , byte age , string position):base(name ,surname,age)
        {
            Position = position;
        }
    }
}
