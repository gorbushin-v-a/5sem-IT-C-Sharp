//5.Дан текстовый файл, каждая строка которого изображает целое число, дополненное слева и справа несколькими пробелами. 
//Вывести сумму этих чисел и их количество. 

using System;
using System.IO;
using Csh_2_library;

namespace Csh_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path");
            string input = Console.ReadLine();//@"D:\C#\1.txt" D:\C#\1.txt

            //Console.WriteLine("Enter number of lines");
            //int col = Convert.ToInt32(Console.ReadLine());
            //using (StreamWriter writer = new StreamWriter(File.Open(input, FileMode.Create)))
            //{
            //    for (int i = 0; i < col; i++)
            //    {
            //        writer.WriteLine(Console.ReadLine());
            //    }
            //}

            TextToIntNumber result = new TextToIntNumber();
            Console.WriteLine(result.ParseText(input));
        }
    }
}
