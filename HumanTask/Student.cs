using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTask
{
    public class Student : Human
    {
        public double Grade { get; set; }

        public Student(string name , string surname , byte age , double grade):base(name , surname , age)
        {
            Grade = grade;   
        }
    }
}
