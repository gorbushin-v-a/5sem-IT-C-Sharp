using System;
using System.Threading.Tasks;

namespace Csh_8_library
{
    class BrakeSpecialist : AWorker
    {
        public BrakeSpecialist(string name)
        {
            nameOfWorker = String.Format("Специалист по тормозам {0}", name);
            nameL = name;
        }
        public override void Repairs(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: сломались тормоза", nameL));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: заезд в боксы", nameL));
            Task.Delay(300).Wait();
            progress.Report(String.Format("{0} меняет тормоза", nameOfWorker));
            Task.Delay(300).Wait();
            progress.Report(String.Format("{0} поменял тормоза", nameOfWorker));
        }
        public void SetEvent(Bolide b)
        {
            b.eventNormal += Repairs;
        }
    }
}
