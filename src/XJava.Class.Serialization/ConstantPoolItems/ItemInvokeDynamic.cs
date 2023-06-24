using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal record ItemInvokeDynamic(ushort BootstrapMethodAttributeIndex, ushort NameAndTypeIndex) : ItemBase(Tag.InvokeDynamic);
}
