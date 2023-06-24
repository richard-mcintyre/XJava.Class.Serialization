using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemMethodTypeSerializer : ItemSerializerBase<ItemMethodType>
    {
        public override ItemMethodType Deserialize(BigEndianBinaryReader reader)
        {
            ushort descriptorIndex = reader.ReadUInt16();
            return new ItemMethodType(descriptorIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemMethodType item) =>
            writer.WriteUInt16(item.DescriptorIndex);
    }
}
