using System;
using System.Collections.Generic;
using System.Reflection;

namespace Csh_8
{
    public class Reflection
    {
        private Assembly dllAssembly = Assembly.LoadFrom("C:\\Users\\gorbushin_v_a\\source\\repos\\Csh_8\\Csh_8_library\\bin\\Debug\\netcoreapp3.1\\Csh_8_library.dll");
        private string InterfaceName { get; set; }
        private Dictionary<string, string> ClassNameClassPath { get; set; } = new Dictionary<string, string>();
        private object CurrObject { get; set; }

        public Reflection(string interfaceName)
        {
            InterfaceName = interfaceName;
        }

        public string[] GetNamesOfInterface(string[] preparedFilesNames, string pathToDirectory)
        {
            var result = new List<string>();

            foreach (var currFileName in preparedFilesNames)
            {
                try
                {
                    Type myType = dllAssembly.GetType(currFileName, true, true);
                        result.Add(myType.Name);
                        ClassNameClassPath.Add(myType.Name, currFileName);
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
                Type myType = dllAssembly.GetType(pathForReflection, true, true);
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

        public bool CreateInstance(string className, string constructorParams)
        {
            string[] constructorParamsSplit;
            constructorParamsSplit = !constructorParams.Equals("") ? constructorParams.Split() : new string[0];

            Console.WriteLine(constructorParamsSplit.Length);

            var pathForReflection = ClassNameClassPath[className];

            try
            {
                Type myType = dllAssembly.GetType(pathForReflection, true, true);

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
                Type myType = dllAssembly.GetType(pathForReflection, true, true);

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

        public void CreateAndInvokeMethod(int n)
        {
            var rand = new Random();
            int speed;
            int carCondition;
            int pathLength;
            for (int i = 1; i < n+1; i++)
            {
                speed = rand.Next(150, 300);
                carCondition = rand.Next(50, 200);
                pathLength = rand.Next(300, 1100);
                string className = "Bolide";
                string constructorParams = String.Format("F{0} {1} {2} {3}", i, speed, carCondition, pathLength);
                string methodName = "StartRace";
                string methodParams = " ";

                CreateInstance(className, constructorParams);
                InvokeMethod(className, methodName, methodParams);
                methodName = "SetEvent";
                InvokeMethod(className, methodName, methodParams);
            }
        }
    }
}