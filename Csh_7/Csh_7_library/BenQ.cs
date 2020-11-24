using System;

namespace Csh_7_library
{
    public class BenQ : SiemensMobile
    {
        public override int NumberOfSIMCards { get; set; }
        public override double Weight { get; set; }
        public int RAM { get; set; }
        public int Camera { get; set; }

        public BenQ(string operatingSystem, int numberOfSIMCards, double weight, int ram, int camera) : base(operatingSystem)
        {
            NumberOfSIMCards = numberOfSIMCards;
            Weight = weight;
            RAM = ram;
            Camera = camera;
        }

        public override string Develop()
        {
            string s = String.Format("Модель BenQ{0}Mb разработана!", RAM);
            return s;
        }

        public override string Sell()
        {
            string s = String.Format("Модель BenQ выставлена на продажу по цене {0}", RAM*Camera*2000);
            return s;
        }

        public override string AbstractInformation()
        {
            string s = String.Format("Информация полей, унаследованных от абстрактного класса\nОперационная система: {0}\nКоличество SIM-карт: {1}\nВес: {2}", OperatingSystem, NumberOfSIMCards, Weight);
            return s;
        }

        public string Information()
        {
            string s = String.Format("Информация собственных полей класса\nОбъём оперативной памяти: {0}\nРазрешение камеры: {1} мегапикселей", RAM, Camera);
            return s;
        }

        public string Companion(string name)
        {
            return String.Format("Компания: BenQ", name);
        }
    }
}
