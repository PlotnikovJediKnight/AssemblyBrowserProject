using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserProject
{
    #region TestSight
    namespace foo
    {
        namespace goo2
        {
            class p { class z { struct zs { class f { } } } }
        }
        namespace goo3
        {
            class y { }
        }
        namespace zoo4
        {
            interface sld
            {

            }
        }
        class Bar
        {

        }
        struct zoo
        {

        }
        namespace goo
        {
            class yty
            {

            }
            namespace ytyty
            {
                interface casd { }
                namespace zzzzzz
                {
                    class flflf { };
                }
            }
        }
    }

    namespace A
    {
        class A
        {

        }
    }

    namespace B
    {
        class A
        {

        }
    }
    #endregion

    public class AssemblyTreeBuilder
    {
        public AssemblyTreeBuilder(String dllPath)
        {
            this.dllPath = dllPath;
        }

        public void Build()
        {
            root = new NamespaceTreeComposite("root", COMPONENT_TYPE.NAMESPACE);
            Assembly asm = Assembly.LoadFrom(dllPath);
            FillTreeByNamespaces(asm);
            FillTreeByTypes(asm);
        }

        private String[] GetSplittedNamespace(String namespaceStr)
        {
            return namespaceStr.Split('.');
        }

        private void AddNamespaceNodes(String[] domains, int curr, TreeComponent comp)
        {
            if (curr == domains.Length) return;
            int index = comp.Find(domains[curr]);
            if (index == -1)
            {
                comp.Add(new NamespaceTreeComposite(domains[curr], COMPONENT_TYPE.NAMESPACE));
                AddNamespaceNodes(domains, curr + 1, comp.GetLastChild());
            }
            else
            {
                AddNamespaceNodes(domains, curr + 1, comp.GetChildAt(index));
            }
        }

        private void FillTreeByNamespaces(Assembly asm)
        {
            foreach (Type type in asm.GetTypes())
            {
                String[] subSpaces = GetSplittedNamespace(type.Namespace);
                AddNamespaceNodes(subSpaces, 0, root);
            }
        }

        private TreeComponent GetDeclaringTreeNode(String[] domains)
        {
            TreeComponent curr = root;
            foreach (string s in domains){
                curr = curr.GetChildAt(curr.Find(s));
            }
            return curr;
        }

        private void FillTreeByTypes(Assembly asm)
        {
            foreach (var type in asm.GetTypes())
            {
                TreeComponent created = TreeComponent.CreateTreeComponent(type, true);
                if (created != null)
                {
                    TreeComponent parent = GetDeclaringTreeNode(GetSplittedNamespace(type.Namespace));
                    AddTypeNodes(type, parent.Add(created));
                }
            }
        }

        private void AddTypeNodes(Type type, TreeComponent node)
        {
            foreach (var nestedType in type.GetTypeInfo()
                                           .DeclaredNestedTypes)
            {
                TreeComponent cmp = null;
                if (nestedType.IsValueType)
                {
                    cmp = node.Add(new StructTreeComposite(nestedType.Name, COMPONENT_TYPE.STRUCT, ACCESS_MODIFIER.INTERNAL));
                }
                else if (nestedType.IsClass)
                {
                    cmp = node.Add(new ClassTreeComposite(nestedType.Name, COMPONENT_TYPE.CLASS, ACCESS_MODIFIER.PUBLIC));
                }
                
                AddTypeNodes(nestedType, cmp);
            }
        }

        public TreeComponent GetRoot() { return root; }

        private TreeComponent root;
        private String dllPath;
    }


}
