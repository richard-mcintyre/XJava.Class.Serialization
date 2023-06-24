using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal record ItemNone() : ItemBase(Tag.None)
    {
        public static ItemNone Instance { get; } = new ItemNone();
    }
}

