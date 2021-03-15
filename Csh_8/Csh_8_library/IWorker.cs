using System;

namespace Csh_8_library
{
    public interface IWorker
    {
        string nameOfWorker { get; set; }
        string nameL { get; set; }
        void Repairs(IProgress<string> progress);
    }
}
