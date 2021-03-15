/*
В зависимости от задачи необходимо смоделировать ситуацию/процесс. В каждой модели есть набор возможных ситуаций. Для некоторых событий 
необходимо определить вероятность возникновения данного события. Интерфейс необходимо реализовать, используя 3 и более классов.
Для решения задач необходимо использовать:
Делегаты/события.
Многопоточность
Где необходимо рефлексию
На форме должно быть динамическое изменение моделей – все должно двигаться. Иметь возможность добавлять несколько моделей на форму.
 Гонки – смоделировать гонки. Реализовать классы – Болид, Механик, интерфейс – погрузчик. События – Стерлись покрышки – заезд в боксы смена колес, 
Столкновение (с некоторой долей вероятности) – приезжает погрузчик.
*/

using Csh_8;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Csh_8_library
{
    public class Bolide
    {
        public string NameOfBolide { get; set; }
        public int Speed { get; set; }
        public int CarCondition { get; set; }
        public int PathLength { get; set; }
        public delegate void Situation(IProgress<string> progress);
        public event Situation eventCrush;
        public event Situation eventNormal;
        event Situation eventBrake;
        event Situation eventEngine;
        private TiresMechanic tm;
        private BrakeSpecialist bs;
        private EngineMechanic em;
        private Loader l;
        static object locker = new object();

        public Bolide(string nameOfBolid, int speed, int carCondition, int pathLength)
        {
            NameOfBolide = nameOfBolid;
            Speed = speed;
            CarCondition = carCondition;
            PathLength = pathLength;
        }

        public async void StartRace()
        {
            tm = new TiresMechanic(NameOfBolide);
            tm.SetEvent(this);
            bs = new BrakeSpecialist(NameOfBolide);
            bs.SetEvent(this);
            em = new EngineMechanic(NameOfBolide);
            em.SetEvent(this);
            l = new Loader(NameOfBolide);
            l.SetEvent(this);
            var progress = new Progress<string>(s => (Application.Current.MainWindow as MainWindow).OutputText.Text = String.Format("{0}{1}\n", (Application.Current.MainWindow as MainWindow).OutputText.Text, s));

            string result = await Task.Factory.StartNew<string>(
                                                    () => RaceContinue(progress),
                                                    TaskCreationOptions.LongRunning);
            (Application.Current.MainWindow as MainWindow).OutputText.Text = String.Format("{0}{1}\n", (Application.Current.MainWindow as MainWindow).OutputText.Text, result);
            
        }

        private string RaceContinue(IProgress<string> progress)
        {
            
            //Situation sit;
            var rand = new Random();
            int situationInt;
            lock (locker)
            {
                progress.Report(String.Format("{0}: должен проехать {1} метров", NameOfBolide, PathLength));
            }
            for (var i = 0; i < PathLength; i++)
            {
                situationInt = rand.Next(0, CarCondition);
                if (situationInt==1)
                {
                    //sit = Normal;
                    situationInt = rand.Next(0, 16);
                    if (situationInt<1)
                    {
                        //sit = Crush;
                        eventCrush?.Invoke(progress);

                    } 
                    else if (1<=situationInt && situationInt < 5)
                    {
                        //sit = Normal;
                        eventNormal?.Invoke(progress);
                    }
                    else if (5 <= situationInt && situationInt < 11)
                    {
                        //sit = Brake;
                        eventBrake?.Invoke(progress);
                    }
                    else
                    {
                        //sit = Engine;
                        eventEngine?.Invoke(progress);
                    }
                    //sit(progress);
                }
                if(i == 200 || i == 400 || i== 600 || i == 1000)
                {
                    lock (locker)
                    {
                        progress.Report(String.Format("{0}: проехал {1} метров!", NameOfBolide, i));
                    }
                }
                Task.Delay(3600 / Speed).Wait();
            }
            return String.Format("{0}: заезд завершён!", NameOfBolide);
        }

        private void Crush(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: машина вылетает с трассы!", NameOfBolide));
            Task.Delay(500).Wait();
            l.Repairs(progress);
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: машина заменена", NameOfBolide));
            
        }

        private void Normal(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: стёрлись покрышки", NameOfBolide));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: заезд в боксы", NameOfBolide));
            Task.Delay(500).Wait();
            tm.Repairs(progress);
        }

        private void Brake(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: сломались тормоза", NameOfBolide));
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: заезд в боксы", NameOfBolide));
            Task.Delay(500).Wait();
            bs.Repairs(progress);
        }

        private void Engine(IProgress<string> progress)
        {
            Task.Delay(500).Wait();
            progress.Report(String.Format("{0}: двигатель повреждён", NameOfBolide));
            Task.Delay(500).Wait();
            em.Repairs(progress);
        }
    }
}