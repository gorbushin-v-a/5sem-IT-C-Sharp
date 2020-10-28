using System;
using System.Collections.Generic;
using System.Linq;

namespace Csh_1_library
{
    public class City
    {
        private List<Citizen> citizens;
        public City()
        {
            citizens = new List<Citizen>();
            //this.FillCity();
        }

        public void AddCitizen(string name)
        {
            citizens.Add(new Citizen(name));
        }
        public void AddRelative(int c1, int c2)
        {
            citizens[c1].citizenChilds.Add(citizens[c2]);
        }

        public List<Relative> FindAllRelatives()
        {
            List<Relative> relatives = new List<Relative>();

            foreach (Citizen cit in this.citizens)
            {
                if (cit.citizenChilds.Count > 0)
                {
                    if (cit.citizenChilds.Count > 1)
                    {
                        for (int i = 0; i < cit.citizenChilds.Count - 1; i++)
                        {
                            for (int j = i + 1; j < cit.citizenChilds.Count; j++)
                            {
                                relatives.Add(new Relative(cit.citizenChilds[i], cit.citizenChilds[j], "БРАТЬЯ"));
                            }

                        }
                    }

                    foreach (Citizen rel in cit.citizenChilds)
                    {
                        relatives.Add(new Relative(cit, rel, "ОТЕЦ-СЫН"));

                        if (rel.citizenChilds.Count > 0)
                        {
                            foreach (Citizen relrel in rel.citizenChilds)
                            {
                                relatives.Add(new Relative(cit, relrel, "ДЕД-ВНУК"));
                            }
                        }
                    }
                }
            }
            return relatives;
        }

        public string PrintAllRels(List<Relative> rels)
        {
            string text = "";
            foreach (Relative rel in rels)
            {
                text += string.Format("{0} -> {1} [{2}]", rel.ancestor.name, rel.descedant.name, rel.relativeLabel);
                text += "\n";
            }
            return text;
        }
    }
}
