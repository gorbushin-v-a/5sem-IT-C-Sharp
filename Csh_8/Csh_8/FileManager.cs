using System;
using System.IO;
using System.Linq;

namespace Csh_8
{
    public class FileManager
    {
        public string[] GetStringFromDir(string pathToDir)
        {
            try
            {
                var rootForSearch = pathToDir.Split('\\').Last();
                string[] files = Directory.GetFiles(pathToDir, "*.cs", SearchOption.AllDirectories);
                for (var i = 0; i < files.Length; i++)
                {
                    var filePath = files[i];
                    files[i] = rootForSearch + filePath
                        .Split(rootForSearch)[1]
                        .Replace("\\", ".")
                        .Replace(".cs", "");
                }
                return files;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new[] {""};
            }   
        }
    }
}