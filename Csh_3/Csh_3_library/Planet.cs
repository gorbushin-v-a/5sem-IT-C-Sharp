using System;
using System.Collections.Generic;

namespace Csh_3_library
{
    public class Planet
    {
        string name;
        List<Continent> continents;
        List<Ocean> oceans;
        List<Island> islands;

        public Planet(string nameOfPlanet)
        {
            name = nameOfPlanet;
            continents = new List<Continent>();
            oceans = new List<Ocean>();
            islands = new List<Island>();
        }

        public void AddContinent(Continent continent)
        {
            continents.Add(continent);
        }

        public void AddOcean(Ocean ocean)
        {
            oceans.Add(ocean);
        }

        public void AddIsland(Island island)
        {
            islands.Add(island);
        }

        public string ReturnName()
        {
            return this.name;
        }

        public string ReturnInformationOfContinents()
        {
            string res = "Count of continents: " + continents.Count + "\n";
            for (int i = 0; i < continents.Count; i++)
            {
                res += continents[i].ToString();
            }
            return res;
        }

        public string ReturnInformationOfOceans()
        {
            string res = "Count of oceans: " + oceans.Count + "\n";
            for (int i = 0; i < oceans.Count; i++)
            {
                res += oceans[i].ToString();
            }
            return res;
        }

        public string ReturnInformationOfIslands()
        {
            string res = "Count of islands: "+islands.Count+"\n";
            for (int i = 0; i< islands.Count; i++)
            {
                res += islands[i];
            }
            return res;
        }
    }
}
