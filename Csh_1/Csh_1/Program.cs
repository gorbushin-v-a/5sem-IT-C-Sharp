//5.Задано конечное множество имен жителей некоторого города, причем для каждого из жителей перечислены имена его детей. 
//Жители А и Б называются родственниками, если:
//либо А — ребенок Б
//либо Б — ребенок А
//либо существует некий В такой, что А является родственником В, а В является родственником Б.
//Перечислить все пары жителей города, которые являются родственниками.

using System;
using System.Collections.Generic;
using Csh_1_library;

namespace Csh_1
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            Console.WriteLine("Enter number of citizens");
            int numberOfCitizens = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCitizens; i++)
            {
                Console.WriteLine("Enter name of citizen");
                city.AddCitizen(Console.ReadLine());
            }
            Console.WriteLine("Enter number of contacts");
            int numberOfContacts = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfContacts; i++)
            {
                Console.WriteLine("Enter number of citizen 1");
                int c1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number of citizen 2");
                int c2 = Convert.ToInt32(Console.ReadLine());
                city.AddRelative(c1, c2);
            }
            List<Relative> relatives = city.FindAllRelatives();
            Console.WriteLine(city.PrintAllRels(relatives));
        }
    }
}
