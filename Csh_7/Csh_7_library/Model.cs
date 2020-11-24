using System;

namespace Csh_7_library
{
    public class Model : SiemensMobile
    {
        public override int NumberOfSIMCards { get; set; }
        public override double Weight { get; set; }
        public string NameOfModel { get; set; }
        public int Cost { get; set; }

        public Model(string operatingSystem, int numberOfSIMCards, double weight, string nameOfModel, int cost) : base(operatingSystem)
        {
            NumberOfSIMCards = numberOfSIMCards;
            Weight = weight;
            NameOfModel = nameOfModel;
            Cost = cost;
        }

        public override string Develop()
        {
            string s = String.Format("Модель {0} разработана!", NameOfModel);
            return s;
        }

        public override string Sell()
        {
            string s = String.Format("Модель {0} выставлена на продажу по цене {1}", NameOfModel, Cost);
            return s;
        }

        public override string AbstractInformation()
        {
            string s = String.Format("Информация полей, унаследованных от абстрактного класса\nОперационная система: {0}\nКоличество SIM-карт: {1}\nВес: {2}", OperatingSystem, NumberOfSIMCards, Weight);
            return s;
        }

        public string Information()
        {
            string s = String.Format("Информация собственных полей класса\nНаименование модели: {0}\nЦена: {1}", NameOfModel, Cost);
            return s;
        }

        public string Companion()
        {
            return "Компания: Siemens mobile";
        }
    }
}