//Поля и функция «качества» (Q ) класса 1 - го уровня
//  Компьютер: 
//  -наименование процессора;
//-тактовая частота процессора(МГц); -объем оперативной памяти(Мб). Q = (0, 1·частота) +память
//Поле и функция «качества» Qp класса 2-го уровня  
//P:  объем винчестера(Гб)
//Qp = Q + 0,5·Р 

using System;
using Csh_4_library;

namespace Csh_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name of cook");
            string nameOfBook = Console.ReadLine();
            Console.WriteLine("Enter number of pages");
            int numberOfPages = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cost of book");
            double costOfBook = Convert.ToDouble(Console.ReadLine());

            ProgrammingTutorial book1 = new ProgrammingTutorial(nameOfBook, numberOfPages, costOfBook);
            Console.WriteLine(book1.FinfInformation());
            Console.WriteLine("Q: "+book1.FinfQuality());

            Console.WriteLine("Enter name of cook");
            string nameOfBook1 = Console.ReadLine();
            Console.WriteLine("Enter number of pages");
            int numberOfPages1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cost of book");
            double costOfBook1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter year of book");
            int yearOfBook1 = Convert.ToInt32(Console.ReadLine());

            ProgrammingTutorial book2 = new ProgrammingTutorialWithYear(nameOfBook1, numberOfPages1, costOfBook1, yearOfBook1);
            Console.WriteLine(book2.FinfInformation());
            Console.WriteLine("Qp: " + book2.FinfQuality());

        }
    }
}
