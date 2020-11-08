using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Progmet_Adressbok
{
    class Program
    {
        class Person
        {
            public string newname, newadress, newphone, newemail;

            public Person(string name, string adress, string phone, string email)
            {
                newname = name;
                newadress = adress;
                newphone = phone;
                newemail = email;
            }
        }
        static void Main(string[] args)
        {

            string fileName = @"C:\Users\Oscar\bin\adressbok.txt";
            List<Person> people = new List<Person>();
            bool quit = false;
            
            using (StreamReader file = new StreamReader(fileName))
            {


                while ((fileName = file.ReadLine()) != null)
                {
                    string[] info = fileName.Split(',');
                    // Console.WriteLine(line);
                    // Console.WriteLine("{0} - {1}", words[0], words[1]);
                    people.Add(new Person(info[0], info[1], info[2], info[3]));
                }
                file.Close();

            }
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i] != null)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}",
                        people[i].newname, people[i].newadress, people[i].newphone, people[i].newemail);
                }
            }
            while (!quit)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    return;
                }
                else if (input == "show")
                {
                    Console.WriteLine("{0,-17}{1,-23}{2,-14}{3}", "Namn", "Adress", "Telefon", "Email");
                    Console.WriteLine("*************************************************************************************************");
                       
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (people[i] != null)
                        {
                            
                            Console.WriteLine("{0,-15} {1,-22} {2,-13} {3}",
                                people[i].newname, people[i].newadress, people[i].newphone, people[i].newemail);
                            
                        }
                    }
                    Console.WriteLine("*************************************************************************************************");
                }
                else if (input == "add")
                {

                    Console.Write("New contact name: ");
                    string name = Console.ReadLine();
                    Console.Write("The address: ");
                    string address = Console.ReadLine();
                    Console.Write("The Phone number: ");
                    string phone = Console.ReadLine();
                    Console.Write("The E-mail: ");
                    string mail = Console.ReadLine();
                    people.Add(new Person(name, address, phone, mail));
                    Console.WriteLine("New contact added!");

                }
            }
        }
    }
}
