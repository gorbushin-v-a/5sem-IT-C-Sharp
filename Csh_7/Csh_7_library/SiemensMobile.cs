namespace Csh_7_library
{
    public abstract class SiemensMobile : Mobile
    {
        public string OperatingSystem { get; set; }
        public abstract int NumberOfSIMCards { get; set; }
        public abstract double Weight { get; set; }

        protected SiemensMobile(string operatingSystem)
        {
            OperatingSystem = operatingSystem;
        }
        public abstract string Develop();
        public abstract string Sell();
        public abstract string AbstractInformation();
    }
}
