using System.Collections.Generic;

namespace Csh_1_library
{
    public class Citizen
    {
        public string name;
        public List<Citizen> citizenChilds;

        public Citizen(string citizenName)
        {
            name = citizenName;
            citizenChilds = new List<Citizen>();

        }
    }
}
