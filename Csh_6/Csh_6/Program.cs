/*
Для интерфейса необходимо определить 1 свойство и 2 метода. 
Абстрактный класс должен содержать 3-5 свойств и 3-5 методов(включая унаследованные свойства интерфейса). 
Класс должен содержать дополнительно 2 свойства и 2 метода.
В программе реализовать работу со списком объектов, который должен содержать объекты типа интерфейса.

5.  interface Mobile -> abstract class Siemens Mobile -> class Model.
*/

using System;
using System.Collections.Generic;
using Csh_6_library;

namespace Csh_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mobile> mobiles = new List<Mobile>();

            Console.WriteLine("Введите количество мобильных телефонов");
            int numberOfMobiles = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfMobiles; i++)
            {
                Console.WriteLine("Введите операционную систему");
                string operatingSystem = Console.ReadLine();
                Console.WriteLine("Введите количество SIM-карт");
                int numberOfSIMCards = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес устройства");
                double weight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите название модели");
                string nameOfModel = Console.ReadLine();
                Console.WriteLine("Введите стоимость");
                int cost = Convert.ToInt32(Console.ReadLine());
                Mobile mobile = new Model(operatingSystem, numberOfSIMCards, weight, nameOfModel, cost);
                mobiles.Add(mobile);
            }

            for (int i = 0; i < numberOfMobiles; i++)
            {
                Console.WriteLine("");
                mobiles[i].Develop();
                mobiles[i].Sell();
                Model model = (Model)mobiles[i];
                model.AbstractInformation();
                model.Information();
                model.Companion();
            }
        }
    }
}
