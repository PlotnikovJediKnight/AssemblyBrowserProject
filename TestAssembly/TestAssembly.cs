using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region NamespaceTest
namespace TestAssembly
{
    namespace N1 { namespace T1 { } namespace T2 { namespace X { struct D { } } } }
    namespace N2 { namespace F1 { } namespace F2 { class A { } class B { } class C { } } namespace F3 { } }
    namespace N3 { namespace P1 { } }
    namespace N4 { class T { } }

    class A { }
    class B { }
    class C { }
}

class A { }
struct B { }
#endregion
