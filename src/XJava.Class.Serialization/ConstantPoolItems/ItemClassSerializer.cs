using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemClassSerializer : ItemSerializerBase<ItemClass>
    {
        public override ItemClass Deserialize(BigEndianBinaryReader reader)
        {
            ushort nameIndex = reader.ReadUInt16();
            return new ItemClass(nameIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemClass item) =>
            writer.WriteUInt16(item.NameIndex);
    }
}
