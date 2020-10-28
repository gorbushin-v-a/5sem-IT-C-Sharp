using System;

namespace Csh_4_library
{
    public class ProgrammingTutorialWithYear : ProgrammingTutorial
    {
        int year;
        public ProgrammingTutorialWithYear(string name, int numberOfPages, double cost, int year) : base(name, numberOfPages, cost)
        {
            this.year = year;
        }

        public override double FinfQuality()
        {
            return base.FinfQuality() - 0.2*(DateTime.Now.Year - year);
        }

        public override string FinfInformation()
        {
            return base.FinfInformation()+" Year: "+ this.year;
        }
    }
}
