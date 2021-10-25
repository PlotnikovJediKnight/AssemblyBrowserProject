using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserProject
{
    public class AssemblyTreeBuilder
    {
        public AssemblyTreeBuilder()
        {

            Assembly assembly = Assembly.GetAssembly(typeof(DateTime));
            foreach (var exportedType in assembly.GetExportedTypes())
            {
                var parentNode = treeView1.Nodes.Add(exportedType.Name);
                AddNodes(exportedType, parentNode);
            }
        }

        private void AddNodes(Type type, TreeNode node)
        {
            foreach (var nestedType in type.GetNestedTypes())
            {
                var nestedNode = node.Nodes.Add(nestedType.Name);
                AddNodes(nestedType, nestedNode);
            }
        }
    }


}
