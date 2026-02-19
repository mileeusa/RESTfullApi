using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions
{
    public class CSharpTypeOps
    {
        public static void ShowAllMethods(Type type)
        {
            foreach(var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                var paramDescriptions = string.Join
                    (", ", parameters
                    .Select(p => $"{p.ParameterType.Name} {p.Name}").ToArray());

                Console.WriteLine("{0} {1} {2}", method.ReturnType, method.Name, paramDescriptions);
            }
        }

        public static void CSharpTypeOps_Test()
        {
            Console.WriteLine("Methods of System.String:");
            ShowAllMethods(typeof(string));
            Console.WriteLine();
            Console.WriteLine("Methods of System.Int32:");
            ShowAllMethods(typeof(int));
        }   
    }
}
