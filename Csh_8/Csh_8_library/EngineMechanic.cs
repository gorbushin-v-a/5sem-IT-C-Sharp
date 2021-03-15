using System;
using System.Threading.Tasks;

namespace Csh_8_library
{
    class EngineMechanic : AWorker
    {
        public EngineMechanic(string name)
        {
            nameOfWorker = String.Format("Специалист по двигателю {0}", name);
            nameL = name;
        }
        public override void Repairs(IProgress<string> progress)
        {

            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: двигатель повреждён", nameL));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0} меняет чинит двигатель", nameOfWorker));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0} починил двигатель", nameOfWorker));
        }
        public void SetEvent(Bolide b)
        {
            b.eventNormal += Repairs;
        }
    }
}
