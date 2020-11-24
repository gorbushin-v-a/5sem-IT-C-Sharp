using System;

namespace Csh_7_library
{
    public class TestClass: SiemensMobile
    {
        public override int NumberOfSIMCards { get; set; }
        public override double Weight { get; set; }
        public string TestString { get; set; }
        public int TestInt { get; set; }
        public bool TestBoolean { get; set; }

        public TestClass(string operatingSystem, int numberOfSIMCards, double weight, string testString, int testInt, bool testBoolean) : base(operatingSystem)
        {
            NumberOfSIMCards = numberOfSIMCards;
            Weight = weight;
            TestString = testString;
            TestInt = testInt;
            TestBoolean = testBoolean;
        }

        public override string Develop()
        {
            string s = String.Format("Модель {0} поставлена на разработку!", TestString);
            return s;
        }

        public override string Sell()
        {
            string s = String.Format("Модель  {0} выставлена на продажу по цене {1}", TestString, TestInt);
            return s;
        }

        public override string AbstractInformation()
        {
            string s = String.Format("Информация полей, унаследованных от абстрактного класса\nОперационная система: {0}\nКоличество SIM-карт: {1}\nВес: {2}", OperatingSystem, NumberOfSIMCards, Weight);
            return s;
        }

        public string Information()
        {
            string s = String.Format("Информация собственных полей класса\nTestString: {0}\nTestInt: {1}", TestString, TestInt);
            return s;
        }

        public string Test()
        {
            return "Test";
        }

        public string Quality(int test)
        {
            if (TestBoolean)
            {
                return String.Format("{0}",(NumberOfSIMCards+Weight+TestInt)* test);
            }
            else
            {
                return "Boolean is false";
            }
            
        }
    }
}

