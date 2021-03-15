using Csh_8;
using System;
using System.Threading.Tasks;
//using System.Windows;

namespace Csh_8_library
{
    public class TiresMechanic : AWorker
    {
        public TiresMechanic(string name)
        {
            nameOfWorker = String.Format("Специалист по колёсам {0}", name);
            nameL = name;
        }
        /**public async void PrepareABatchOfTires()
        {
            var progress = new Progress<string>(s => (Application.Current.MainWindow as MainWindow).OutputText.Text = String.Format("{0}{1}\n", (Application.Current.MainWindow as MainWindow).OutputText.Text, s));
            string result = await Task.Factory.StartNew<string>( () => PrepareABatchOfTiresContinue(progress), TaskCreationOptions.LongRunning);
            (Application.Current.MainWindow as MainWindow).OutputText.Text = String.Format("{0}{1}\n", (Application.Current.MainWindow as MainWindow).OutputText.Text, result);
        }
        public string PrepareABatchOfTiresContinue(IProgress<string> progress)
        {
            for (var i = 0; i < 2; i++)
            {
                progress.Report(String.Format("{0}: механик готовит новую партию покрышек", nameOfWorker));
                Task.Delay(5000).Wait();
            }
            return String.Format("{0}: покрышки доставлены", nameOfWorker);
        }**/

        public void SetEvent(Bolide b)
        {
            b.eventNormal += Repairs;
        }

        public override void Repairs(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: стёрлись покрышки", nameL));
            Task.Delay(200).Wait();
            progress.Report(String.Format("{0}: заезд в боксы", nameL));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0} заменил колёса", nameOfWorker));
            //PrepareABatchOfTires();
        }
    }
}
