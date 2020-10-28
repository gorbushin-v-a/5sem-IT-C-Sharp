using System;
using System.Collections.Generic;
using System.Text;

namespace Csh_3_library
{
    public class Island
    {
        public string Name { get; set; }
        public double Population { get; set; }

        public Island(string name, double population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return "    Name: " + Name + " Population: " + Population + "\n";
        }
    }
}
