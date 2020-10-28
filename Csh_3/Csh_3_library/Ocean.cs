using System;
using System.Collections.Generic;
using System.Text;

namespace Csh_3_library
{
    public class Ocean
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double Depth { get; set; }

        public Ocean(string name, double temperature, double depth)
        {
            Name = name;
            Temperature = temperature;
            Depth = depth;
        }

        public override string ToString()
        {
            return "    Name: " + Name + " Temperature: " + Temperature + " Depth: " + Depth + "\n";
        }
    }
}
