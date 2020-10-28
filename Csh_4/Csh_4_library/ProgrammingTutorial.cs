
namespace Csh_4_library
{
    public class ProgrammingTutorial
    {
        string name;
        int numberOfPages;
        double cost;

        public ProgrammingTutorial(string name, int numberOfPages, double cost)
        {
            this.name = name;
            this.numberOfPages = numberOfPages;
            this.cost = cost;
        }

        public virtual double FinfQuality()
        {
            return cost / numberOfPages;
        }

        public virtual string FinfInformation()
        {
            return "Name: "+ this.name+" Pages: "+ this.numberOfPages+" Cost: "+ this.cost;
        }
    }
}
