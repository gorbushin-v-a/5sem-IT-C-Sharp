using System;
using System.Collections.Generic;
using System.Reflection;

namespace Csh_7_library
{
    public class Reflection
    {
        private string InterfaceName { get; set; }
        private Dictionary<string, string> ClassNameClassPath { get; set; } = new Dictionary<string, string>();
        private object CurrObject { get; set; }

        public Reflection(string interfaceName)
        {
            InterfaceName = interfaceName;
        }

        public string[] GetNamesOfInterface(string[] preparedFilesNames)
        {
            var result = new List<string>();

            foreach (var currFileName in preparedFilesNames)
            {
                try
                {
                    Type myType = Type.GetType(currFileName, true, true);
                    if (myType.GetInterface(InterfaceName) != null && !myType.IsAbstract && !myType.IsInterface)
                    {
                        result.Add(myType.Name);
                        ClassNameClassPath.Add(myType.Name, currFileName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }
            }

            return result.ToArray();
        }

        public void GetClassFields(string name)
        {
            var pathForReflection = ClassNameClassPath[name];
            try
            {
                Type myType = Type.GetType(pathForReflection, true, true);
                foreach (var VARIABLE in myType.GetFields())
                {
                    Console.WriteLine(VARIABLE.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public Dictionary<string, List<string>> GetClassMethods(string className)
        {
            var nameParam = new Dictionary<string, List<string>>();
            var pathForReflection = ClassNameClassPath[className];
            try
            {
                Type myType = Type.GetType(pathForReflection, true, true);

                foreach (var methodInfo in myType.GetMethods())
                {
                    var paramList = new List<string>();
                    foreach (var param in methodInfo.GetParameters())
                    {
                        paramList.Add(param.ParameterType.Name + " " + param.Name);
                    }
                    nameParam.Add(methodInfo.Name, paramList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            return nameParam;
        }

        public Dictionary<string, List<string>> GetClassConstructors(string className)
        {
            var constrParam = new Dictionary<string, List<string>>();
            var pathForReflection = ClassNameClassPath[className];
            try
            {
                Type myType = Type.GetType(pathForReflection, true, true);

                var counter = 0;
                foreach (var constructorInfo in myType.GetConstructors())
                {
                    var paramList = new List<string>();
                    foreach (var param in constructorInfo.GetParameters())
                    {
                        paramList.Add(param.ParameterType.Name + " " + param.Name);
                    }

                    constrParam.Add(constructorInfo.Name + counter, paramList);
                    counter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            return constrParam;
        }

        public bool CreateInstance(string className, string constructorParams)
        {
            string[] constructorParamsSplit;
            constructorParamsSplit = !constructorParams.Equals("") ? constructorParams.Split() : new string[0];

            Console.WriteLine(constructorParamsSplit.Length);

            var pathForReflection = ClassNameClassPath[className];

            try
            {
                Type myType = Type.GetType(pathForReflection, true, true);

                ConstructorInfo constructor = myType.GetConstructor(Type.EmptyTypes);
                foreach (var currConstrInfo in myType.GetConstructors())
                {
                    if (currConstrInfo.GetParameters().Length == constructorParamsSplit.Length)
                    {
                        constructor = currConstrInfo;
                    }
                }

                object[] constructorParamArray = new object[constructorParamsSplit.Length];
                int counterFirst = 0;
                foreach (var parameterInfo in constructor.GetParameters())
                {
                    constructorParamArray[counterFirst] = Convert.ChangeType(constructorParamsSplit[counterFirst],
                        parameterInfo.ParameterType);
                    counterFirst++;
                }

                CurrObject = constructor.Invoke(constructorParamArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return false;
            }

            return true;
        }

        public string InvokeMethod(string className, string methodName, string methodParams)
        {
            string[] methodParamsSplit = methodParams.Split();

            var pathForReflection = ClassNameClassPath[className];

            try
            {
                Type myType = Type.GetType(pathForReflection, true, true);

                MethodInfo method = myType.GetMethod(methodName);
                object[] methodParamArray = new object[method.GetParameters().Length];
                int counterSecond = 0;
                foreach (var parameterInfo in method.GetParameters())
                {
                    methodParamArray[counterSecond] =
                        Convert.ChangeType(methodParamsSplit[counterSecond], parameterInfo.ParameterType);
                    counterSecond++;
                }

                return method.Invoke(CurrObject, methodParamArray)?.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return "";
            }
        }
    }
}