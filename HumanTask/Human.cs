using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTask
{
    public class Human
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        private Human()
        {
            _id++;
            Id = _id;
        }
        public Human(string name , string surname , byte age) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
