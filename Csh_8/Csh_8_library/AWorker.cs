using System;

namespace Csh_8_library
{
    public abstract class AWorker : IWorker
    {
        public string nameOfWorker { get; set; }
        public string nameL { get; set; }

        public abstract void Repairs(IProgress<string> progress);
    }
}
