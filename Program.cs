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
            public string name, adress, phone, email;

            public Person(string name, string adress, string phone, string email)
            {
                this.name = name;
                this.adress = adress;
                this.phone = phone;
                this.email = email;
            }
        }
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Oscar\bin\adressbok.txt"; //Change to appropriate path for yourself
            List<Person> people = new List<Person>();
            bool quit = false;
            string[] infobook = File.ReadAllLines(fileName); //found@https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/          
            for (int i = 0; i < infobook.Length; i++)
            {
                string[] info = infobook[i].Split(',');
                people.Add(new Person(info[0], info[1], info[2], info[3]));
            }

            Menu();
            
            while (!quit)
            {
                Console.Write(">");
                string input = Console.ReadLine().ToLower();
                if (input == "avsluta")
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen åter!");
                    return;
                }
                else if (input == "visa")
                {
                    Console.WriteLine("\n{0,-18}{1,-23}{2,-16}{3}", "Namn", "Adress", "Telefon", "Email");
                    Console.WriteLine("*************************************************************************************************");

                    for (int i = 0; i < people.Count; i++)
                    {
                        if (people[i] != null)
                        {

                            Console.WriteLine("{0,-17} {1,-22} {2,-15} {3}",
                                people[i].name, people[i].adress, people[i].phone, people[i].email);

                        }
                    }
                    Console.WriteLine("*************************************************************************************************");
                }
                else if (input == "ny")
                {
                    Console.Write("\nAnge namn: ");
                    string name = Console.ReadLine();
                    Console.Write("Ange adress: ");
                    string address = Console.ReadLine();
                    Console.Write("Ange telefonnummer: ");
                    string phone = Console.ReadLine();
                    Console.Write("Ange E-mail: ");
                    string mail = Console.ReadLine();
                    people.Add(new Person(name, address, phone, mail));
                    Console.WriteLine("\nNy kontakt tillagd");
                    //Saving right away when adding new
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < people.Count(); i++)
                        {
                            sw.WriteLine("{0}, {1}, {2}, {3}", people[i].name, people[i].adress, people[i].phone, people[i].email);

                        }
                    }
                }
                else if (input == "radera")
                {
                    Console.Write("\nSkriv namnet på personen du vill\nta bort från dina kontakter: ");
                    string name = Console.ReadLine().ToLower();
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (name == people[i].name.ToLower())
                        {
                            Console.WriteLine("\nTog bort {0} från dina kontakter", name);
                            people.RemoveAt(i);
                        }                        
                    }
                    //Deleting right away
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < people.Count(); i++)
                        {
                            sw.WriteLine("{0}, {1}, {2}, {3}", people[i].name, people[i].adress, people[i].phone, people[i].email);

                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Ogiltigt kommando: {input}");
                }
            }
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("     Välkommen till din Adressbok!    ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(" 'visa' för att se dina kontakter     ");
            Console.WriteLine(" 'ny' för at skapa en ny kontakt      ");
            Console.WriteLine(" 'radera' för at ta bort en kontakt   ");
            Console.WriteLine(" 'avsluta' för att stänga programmet  ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("    Kontakter sparas automatiskt!     ");
            Console.WriteLine("--------------------------------------");
        }
    }
}
