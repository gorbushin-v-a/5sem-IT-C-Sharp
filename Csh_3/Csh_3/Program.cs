//Создать объект класса Планета, используя классы Материк, Океан, Остров. Методы: вывести название материка, планеты, количество материков.

using System;
using System.Collections.Generic;
using Csh_3_library;

namespace Csh_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name of plenet");
            string nameOfPlanet = Console.ReadLine();
            Planet planet = new Planet(nameOfPlanet);

            Console.WriteLine("Enter number of continents");
            int numberOfContinents = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfContinents; i++)
            {
                Console.WriteLine("Enter name of continent");
                string nameOfContinent = Console.ReadLine();
                Console.WriteLine("Enter area of continent");
                double areaOfContinent = Convert.ToDouble(Console.ReadLine());
                Continent continent = new Continent(nameOfContinent, areaOfContinent);
                planet.AddContinent(continent);
            }

            Console.WriteLine("Enter number of oceans");
            int numberOfOceans = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfOceans; i++)
            {
                Console.WriteLine("Enter name of ocean");
                string nameOfOcean = Console.ReadLine();
                Console.WriteLine("Enter temperature of ocean");
                double temperatureOfOcean = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter depth of ocean");
                double depthOfOcean = Convert.ToDouble(Console.ReadLine());
                Ocean ocean = new Ocean(nameOfOcean, temperatureOfOcean, depthOfOcean);
                planet.AddOcean(ocean);
            }

            Console.WriteLine("Enter number of islands");
            int numberOfIslands = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfIslands; i++)
            {
                Console.WriteLine("Enter name of island");
                string nameOfIsland = Console.ReadLine();
                Console.WriteLine("Enter population of island");
                double populationOfIsland = Convert.ToDouble(Console.ReadLine());
                Island island = new Island(nameOfIsland, populationOfIsland);
                planet.AddIsland(island);
            }

            Console.WriteLine("Name of planet: "+planet.ReturnName()+"\n");
            Console.WriteLine(planet.ReturnInformationOfContinents() + "\n");
            Console.WriteLine(planet.ReturnInformationOfOceans() + "\n");
            Console.WriteLine(planet.ReturnInformationOfIslands() + "\n");
        }
    }
}
