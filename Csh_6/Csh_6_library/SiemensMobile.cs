namespace Csh_6_library
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
        public abstract void Develop();
        public abstract void Sell();
        public abstract void AbstractInformation();
    }
}
