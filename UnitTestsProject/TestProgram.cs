using System;
using System.Collections.Generic;
using System.Reflection;
using AssemblyBrowserProject;
using TestsProject;

namespace UnitTestsProject
{

    class TestProgram
    {
        delegate void test_method();
        static TreeComponent tree;

        static void TestNamespacesStructure()
        {
            TreeComposite rootNamespace = tree.GetTreeComposite();

            TestFramework.AssertEqual(rootNamespace.Name, "root", "Root namespace hasn't been created!");

            //TestFramework.AssertEqual(rootNamespace.Find()
        }

        static void Main(string[] args)
        {
            AssemblyTreeBuilder asm = 
                new AssemblyTreeBuilder("D:\\БГУИР\\Третий курс\\newRepos\\AssemblyBrowserProject\\TestAssembly\\bin\\Debug\\TestAssembly.dll");
            asm.Build();
            tree = asm.GetRoot();


            test_method testDelegate;
            TestRunner<test_method> r = new TestRunner<test_method>();

            testDelegate = TestNamespacesStructure;
            r.RunTest(testDelegate, "NamespaceStructureTest");

            Console.ReadLine();
        }
    }
}
