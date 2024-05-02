using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Channels;

namespace HumanTask
{
    internal class Program
    {
        static void Main()
        {
            List<Employe> employes = new List<Employe>();
            List<Student> students = new List<Student>();
            employes.AddRange(new Employe[]
            {
                new Employe("Ali" , "Aliyev" , 21 , "IT"),
                new Employe("Rufet" , "Asgeov" , 44 , "Topoqraf"),
                new Employe("Elvin" , "Zeynizade" , 50 , "Texnik"),
                new Employe("Fikret" , "Rehimov" , 34 , "Qabyuyan"),
                new Employe("Ferhad" , "Xidirli" , 22 , "Ceo")
            });

            students.AddRange(new Student[]
            {
                new Student("Hikmet" , "Resulzade" , 17 ,88),
                new Student("Fariz" , "Abdullayev" , 18 ,25),
                new Student("Resul" , "Agazade" , 21 ,100),
                new Student("Veli" , "Memmedli" , 22 ,81),
                new Student("Veysel" , "Abdulla" , 23 ,67),
                new Student("Ruslan" , "Huseynzade" , 19 ,78)
            });



            int choice;
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1-Add Student.");
                Console.WriteLine("2-Add Employe.");
                Console.WriteLine("3-Search.");
                Console.WriteLine("0-Quit.");
                Console.Write("Choice : ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------");
                switch (choice)
                {
                    case 1:
                        AddStudent(students);
                        break;
                    case 2:
                        AddEmploye(employes);
                        break;
                    case 3:
                        int choice1;

                        do
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("1=Search for Student");
                            Console.WriteLine("2=Search for Employe");
                            Console.WriteLine("0-Go back");
                            Console.Write("Choice : ");
                            choice1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("-----------------------------");
                            if (choice1 == 1)
                            {
                                SeachStudent(students);
                            }
                            else if(choice1 == 2)
                            {
                                SearchEmploye(employes);
                            }
                            else if (choice == 0)
                            {
                                Console.WriteLine("Going back.....");
                            }

                        } while (choice1 != 0);


                        break;
                    case 4:
                        Console.WriteLine("Exit.......");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }

            } while (choice != 0);
        }

        private static void SearchEmploye(List<Employe> employes)
        {
            Console.Write("Postion : ");
            string position = Console.ReadLine();

            List<Employe> sortedEmploye = employes.FindAll(x=>x.Position.ToLower().Trim() == position.ToLower().Trim()).ToList();

            if(sortedEmploye.Count == 0)
            {
                Console.WriteLine("Not found:(");
            }
            else
            {
                Console.WriteLine($"-------- Found:{sortedEmploye.Count} students --------");
                int i = 0;
                foreach (var item in sortedEmploye)
                {
                    i++;
                    Console.WriteLine($@"Id --> {item.Id}
Name --> {item.Name}
Grade --> {item.Position}");
                    if(sortedEmploye.Count != i)
                    {
                        Console.WriteLine("-------------------------");
                    }
                }
            }
        }

        private static void SeachStudent(List<Student> students)
        {
        input:
            double minGrade;
            double maxGrade;
            try
            {
                Console.Write("Min grade : ");
                minGrade = double.Parse(Console.ReadLine());
                Console.Write("Max grade : ");
                maxGrade = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong inputs");
                goto input;
            }


            List<Student> sortedList = students.FindAll(x => x.Grade > minGrade && x.Grade < maxGrade).ToList();

            if(sortedList.Count == 0)
            {
                Console.WriteLine("Not found:(");
            }
            else
            {
                int i = 0;
                Console.WriteLine($"-------- Found:{sortedList.Count} students --------");
                foreach (var item in sortedList)
                {
                    i++;
                    Console.WriteLine($@"Id --> {item.Id}
Name --> {item.Name}
Grade --> {item.Grade}");
                    if(sortedList.Count != i)
                    {
                        Console.WriteLine("-------------------------");
                    }
                }
                
            }

        }



        static void AddStudent(List<Student> list)
        {
            (string name, string surname, byte age) = AddHuman();

            double grade;
        grade:
            try
            {
                Console.Write("Grade : ");
                grade = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try again!");
                goto grade;
            }

            Student student = new Student(name, surname, age, grade);
            list.Add(student);

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Added Student --> {student.Id}");
            Console.WriteLine("-----------------------------");
        }
        static void AddEmploye(List<Employe> list)
        {

            (string name, string surname, byte age) = AddHuman();

            Console.Write("Position : ");
            string position = Console.ReadLine();

            Employe employe = new Employe(name,surname, age, position);
            list.Add(employe);

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Added Employe --> {employe.Id}");
            Console.WriteLine("-----------------------------");


        }
        static (string, string, byte) AddHuman()
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Surname : ");
            string surname = Console.ReadLine();
            byte age;
        age:
            try
            {
                Console.Write("Age : ");
                age = byte.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try again!");
                goto age;
            }

            return (name, surname, age);
        }
    }
}
