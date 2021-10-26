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
            TreeComposite curr = tree.GetTreeComposite();

            TestFramework.AssertEqual(curr.Name, "root", "Root namespace hasn't been created!");

            TestFramework.Assert(curr.Find("TestAssembly") >= 0, "TestAssembly namespace should be in root!");
            TestFramework.Assert(curr.Find("A") >= 0, "class A should be in root!");
            TestFramework.Assert(curr.Find("B") >= 0, "class B should be in root!");

            curr = curr.GetChildAt(curr.Find("TestAssembly")).GetTreeComposite();

            TestFramework.Assert(curr.Find("A") >= 0, "class A should be in TestAssembly!");
            TestFramework.Assert(curr.Find("B") >= 0, "class B should be in TestAssembly!");
            TestFramework.Assert(curr.Find("C") >= 0, "class C should be in TestAssembly!");

            TestFramework.Assert(curr.Find("N1") >= 0, "N1 namespace should be in TestAssembly!");
            TestFramework.Assert(curr.Find("N2") >= 0, "N2 namespace should be in TestAssembly!");
            TestFramework.Assert(curr.Find("N4") >= 0, "N4 namespace should be in TestAssembly!");
            TestFramework.AssertEqual(curr.Find("N3"), -1, "N3 namespace should not be in TestAssembly!");

            TreeComposite oldCurr = curr;

            curr = curr.GetChildAt(curr.Find("N4")).GetTreeComposite();
            TestFramework.AssertEqual(curr.Find("T"), 0, "class T should be in N4!");
            curr = oldCurr;

            curr = curr.GetChildAt(curr.Find("N2")).GetTreeComposite();
            TestFramework.AssertEqual(curr.Find("F1"), -1, "F1 namespace should not be in TestAssembly!");
            TestFramework.AssertEqual(curr.Find("F3"), -1, "F3 namespace should not be in TestAssembly!");
            TestFramework.AssertEqual(curr.Find("F2"), 0, "F2 namespace should be in TestAssembly!");

            curr = curr.GetChildAt(curr.Find("F2")).GetTreeComposite();

            TestFramework.Assert(curr.Find("A") >= 0, "class A should be in F2!");
            TestFramework.Assert(curr.Find("B") >= 0, "class B should be in F2!");
            TestFramework.Assert(curr.Find("C") >= 0, "class C should be in F2!");

            curr = oldCurr;
            curr = curr.GetChildAt(curr.Find("N1")).GetTreeComposite();

            TestFramework.AssertEqual(curr.Find("T1"), -1, "T1 namespace should not be in N1!");
            TestFramework.AssertEqual(curr.Find("T2"), 0, "T2 namespace should be in N1!");

            curr = curr.GetChildAt(curr.Find("T2")).GetTreeComposite();
            TestFramework.AssertEqual(curr.Find("X"), 0, "X namespace should be in T2!");
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
