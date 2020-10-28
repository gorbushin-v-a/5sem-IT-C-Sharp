using System;
using System.IO;

namespace Csh_2_library
{
    public class TextToIntNumber
    {
        public TextToIntNumber()
        {

        }

        public string ParseText(string input)
        {
            try
            {
                int counter = 0;
                int sum = 0;
                string line;
                StreamReader file = new StreamReader(input);
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        sum += int.Parse(line);
                    }
                    catch (System.FormatException e)
                    {
                        file.Close();
                        return e.Message;

                    }
                   counter++;
                }
                file.Close();
                string result = "Summ of numbers: "+sum.ToString()+" Count: "+counter.ToString();
                return result;
            }
            catch (FileNotFoundException e) 
            { 
                return e.Message;
            }
        }
    }
}
