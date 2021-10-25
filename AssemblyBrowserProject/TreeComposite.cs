using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserProject
{

    enum ACCESS_MODIFIER
    {
        PUBLIC,
        PRIVATE,
        PROTECTED,
        INTERNAL,
        PROTECTED_INTERNAL,
        PRIVATE_PROTECTED
    }



    enum COMPONENT_TYPE
    {
        FIELD,
        PROPERTY,
        METHOD,
        NAMESPACE,
        CLASS,
        STRUCT
    }

    class TreeComponent
    {
        protected static String GetAccessModifierString(ACCESS_MODIFIER accMod)
        {
            switch (accMod)
            {
                case ACCESS_MODIFIER.PUBLIC: return "public";
                case ACCESS_MODIFIER.PRIVATE: return "private";
                case ACCESS_MODIFIER.PROTECTED: return "protected";
                case ACCESS_MODIFIER.INTERNAL: return "internal";
                case ACCESS_MODIFIER.PROTECTED_INTERNAL: return "protected internal";
                case ACCESS_MODIFIER.PRIVATE_PROTECTED: return "private protected";
            }
            return "";
        }

        public TreeComponent(String name, COMPONENT_TYPE componentType)
        {
            Name = name;
            ComponentType = componentType;
        }

        public virtual void Add(TreeComponent cmp) { throw new NotImplementedException(); }
        public virtual void Remove(TreeComponent cmp) { throw new NotImplementedException(); }
        public virtual TreeComponent GetChildAt(int index) { throw new NotImplementedException(); }

        public String Name { get; set; }
        public COMPONENT_TYPE ComponentType { get; set; }
        public virtual TreeComposite GetTreeComposite() { return null; }
    }

    class TreeLeaf : TreeComponent
    {
        public TreeLeaf(String name, COMPONENT_TYPE componentType) :
            base(name, componentType) { }
    }

    class MethodTreeLeaf : TreeLeaf
    {
        public MethodTreeLeaf(String name, COMPONENT_TYPE componentType, ACCESS_MODIFIER accMod) :
            base(name, componentType)
        { AccessModifier = accMod; }

        public override string ToString()
        {
            return GetAccessModifierString(AccessModifier) + " " + Name + "(...)";
        }

        public ACCESS_MODIFIER AccessModifier { get; set; }
    }

    class PropertyTreeLeaf : TreeLeaf
    {
        public PropertyTreeLeaf(String name, COMPONENT_TYPE componentType, ACCESS_MODIFIER setAccMod, ACCESS_MODIFIER getAccMod) :
            base(name, componentType)
        {
            SetAccessModifier = setAccMod;
            GetAccessModifier = getAccMod;
        }

        public ACCESS_MODIFIER SetAccessModifier { get; set; }
        public ACCESS_MODIFIER GetAccessModifier { get; set; }
    }

    class FieldTreeLeaf : TreeLeaf
    {
        public FieldTreeLeaf(String name, COMPONENT_TYPE componentType, ACCESS_MODIFIER accMod) :
            base(name, componentType)
        { AccessModifier = accMod; }
        public ACCESS_MODIFIER AccessModifier { get; set; }
    }

    class TreeComposite : TreeComponent
    {
        public override void Add(TreeComponent cmp) { components.Add(cmp); }
        public override void Remove(TreeComponent cmp) { components.Remove(cmp); }
        public override TreeComponent GetChildAt(int index) { return components.ElementAt(index); }
        public List<TreeComponent> components = new List<TreeComponent>();

        public TreeComposite(String name, COMPONENT_TYPE componentType) : base(name, componentType) { }
    }

    class NamespaceTreeComposite : TreeComposite
    {
        public NamespaceTreeComposite(String name, COMPONENT_TYPE componentType) : base(name, componentType) { }

        public override string ToString()
        {
            return "namespace " + Name;
        }
    }

    class StructTreeComposite : TreeComposite
    {
        public StructTreeComposite(String name, COMPONENT_TYPE componentType, ACCESS_MODIFIER accMod) : base(name, componentType)
        {
            AccessModifier = accMod;
        }

        public override string ToString()
        {
            return GetAccessModifierString(AccessModifier) + " struct " + Name;
        }

        public ACCESS_MODIFIER AccessModifier { get; set; }
    }

    class ClassTreeComposite : TreeComposite
    {
        public ClassTreeComposite(String name, COMPONENT_TYPE componentType, ACCESS_MODIFIER accMod) : base(name, componentType)
        {
            AccessModifier = accMod;
        }

        public ACCESS_MODIFIER AccessModifier { get; set; }

        public override string ToString()
        {
            return GetAccessModifierString(AccessModifier) + " class " + Name;
        }

    }
}

    
