using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssemblyBrowserProject;
using System.Text;
using System.Threading.Tasks;

namespace fas
{
    namespace asd
    {
        namespace zzz
        {
            class Foo { }
        }
    }
}

namespace UnitTestsProject
{

    class Program
    {
        static void Main(string[] args)
        {
            AssemblyTreeBuilder asm = new AssemblyTreeBuilder("D:\\БГУИР\\Третий курс\\newRepos\\AssemblyBrowserProject\\AssemblyBrowserProject\\bin\\Debug\\AssemblyBrowserProject.dll");
            asm.Build();
            TreeComponent tree = asm.GetRoot();
            //Console.WriteLine(Assembly.GetExecutingAssembly().GetTypes().Length);
            IEnumerable<TypeInfo> e = new Program().GetType()
                                           .GetTypeInfo()
                                           .DeclaredNestedTypes;

            foreach (TypeInfo t in e){
                Console.WriteLine(t.Name);
            }

            Console.ReadLine();
        }
    }
}
