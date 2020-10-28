using System;

namespace Csh_1_library
{
    public class Relative
    {
        public Citizen ancestor;
        public Citizen descedant;
        public string relativeLabel;

        public Relative(Citizen ancestor, Citizen descedant, string relativeLabel)
        {
            this.ancestor = ancestor;
            this.descedant = descedant;
            this.relativeLabel = relativeLabel;
        }
    }
}
