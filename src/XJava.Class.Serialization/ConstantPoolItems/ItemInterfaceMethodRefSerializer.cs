using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemInterfaceMethodRefSerializer : ItemSerializerBase<ItemInterfaceMethodRef>
    {
        public override ItemInterfaceMethodRef Deserialize(BigEndianBinaryReader reader)
        {
            ushort classIndex = reader.ReadUInt16();
            ushort nameAndTypeIndex = reader.ReadUInt16();
            return new ItemInterfaceMethodRef(classIndex, nameAndTypeIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemInterfaceMethodRef item)
        {
            writer.WriteUInt16(item.ClassIndex);
            writer.WriteUInt16(item.NameAndTypeIndex);
        }
    }
}
