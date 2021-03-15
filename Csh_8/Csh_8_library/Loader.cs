using System;
using System.Threading.Tasks;

namespace Csh_8_library
{
    public class Loader: AWorker
    {
        public Loader(string name)
        {
            nameOfWorker = String.Format("Погрузчик {0}", name);
            nameL = name;
        }
        public override void Repairs(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: машина вылетает с трассы!", nameL));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0} меняет машину", nameOfWorker));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: машина заменена", nameL));
        }
        public void SetEvent(Bolide b)
        {
            b.eventNormal += Repairs;
        }
    }
}

