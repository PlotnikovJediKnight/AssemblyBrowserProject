using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserProject
{
    namespace asdf
    {
        namespace sd
        {

        }
    }

    enum COMPONENT_TYPE{
        FIELD,
        PROPERTY,
        METHOD,
        NAMESPACE,
        CLASS,
        STRUCT
    }

    class TreeComponent
    {
        public TreeComponent(String name, COMPONENT_TYPE componentType)
        {
            Name = name;
            ComponentType = componentType;
        }

        public virtual void Add(TreeComponent cmp) { throw new NotImplementedException(); }
        public virtual void Remove(TreeComponent cmp) { throw new NotImplementedException(); }
        public virtual TreeComponent GetChild(int index) { throw new NotImplementedException(); }

        public String Name { get; set;  }
        public COMPONENT_TYPE ComponentType { get; set; }
        public virtual TreeComposite GetTreeComposite() { return null; }
    }

    class TreeLeaf : TreeComponent
    {
        public TreeLeaf(String name, COMPONENT_TYPE componentType, Type memberType) :
            base(name, componentType)
        {
            MemberType = memberType;
        }
        public Type MemberType { get; set; }
    }

    class MethodTreeLeaf : TreeLeaf
    {

    }

    class PropertyTreeLeaf : TreeLeaf
    {

    }

    class FieldTreeLeaf : TreeLeaf {

    }

    class TreeComposite : TreeComponent
    {
        public override void Add(TreeComponent cmp) { throw new NotImplementedException(); }
        public override void Remove(TreeComponent cmp) { throw new NotImplementedException(); }
        public override TreeComponent GetChild(int index) { throw new NotImplementedException(); }
        public List<TreeComponent> components = new List<TreeComponent>();
    }

    class NamespaceTreeComposite : TreeComposite
    {

    }

    class StructTreeComposite : TreeComposite
    {

    }

    class ClassTreeComposite : TreeComposite
    {

    }

}
