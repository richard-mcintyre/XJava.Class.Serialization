using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemNameAndTypeSerializer : ItemSerializerBase<ItemNameAndType>
    {
        public override ItemNameAndType Deserialize(BigEndianBinaryReader reader)
        {
            ushort nameIndex = reader.ReadUInt16();
            ushort descriptorIndex = reader.ReadUInt16();
            return new ItemNameAndType(nameIndex, descriptorIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemNameAndType item)
        {
            writer.WriteUInt16(item.NameIndex);
            writer.WriteUInt16(item.DescriptorIndex);
        }
    }
}
