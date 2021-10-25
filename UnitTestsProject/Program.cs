using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsProject
{
    namespace fas {
        namespace asd
        {
            namespace zzz
            {
                class Foo { }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetTypes()[1].Namespace);
            Console.ReadLine();
        }
    }
}
