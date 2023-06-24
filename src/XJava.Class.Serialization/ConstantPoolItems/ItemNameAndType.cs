using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal record ItemNameAndType(ushort NameIndex, ushort DescriptorIndex) : ItemBase(Tag.NameAndType);
}
