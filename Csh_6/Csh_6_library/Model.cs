using System;

namespace Csh_6_library
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

        public override void Develop()
        {
            Console.WriteLine("Модель "+ NameOfModel + " разработана!");
        }

        public override void Sell()
        {
            Console.WriteLine("Модель " + NameOfModel + " выставлена на продажу по цене "+Cost);
        }

        public override void AbstractInformation()
        {
            Console.WriteLine("Информация полей, унаследованных от абстрактного класса");
            Console.WriteLine("Операционная система: " + OperatingSystem);
            Console.WriteLine("Количество SIM-карт: " + NumberOfSIMCards);
            Console.WriteLine("Вес: " + Weight);
        }

        public void Information()
        {
            Console.WriteLine("Информация собственных полей класса");
            Console.WriteLine("Наименование модели: "+NameOfModel);
            Console.WriteLine("Цена: " + Cost);
        }

        public void Companion()
        {
            Console.WriteLine("Компания: Siemens mobile");
        }
    }
}
