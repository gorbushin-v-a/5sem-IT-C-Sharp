using System;
using System.Collections.Generic;
using System.Text;

namespace Csh_3_library
{
    public class Continent
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public Continent(string name, double area)
        {
            Name = name;
            Area = area;
        }

        public override string ToString() 
        {
            return "    Name: " + Name + " Area: " + Area + "\n";
        }
    }
}
