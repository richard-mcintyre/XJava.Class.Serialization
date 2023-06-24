using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemStringSerializer : ItemSerializerBase<ItemString>
    {
        public override ItemString Deserialize(BigEndianBinaryReader reader)
        {
            ushort stringIndex = reader.ReadUInt16();
            return new ItemString(stringIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemString item) =>
            writer.WriteUInt16(item.StringIndex);
    }
}
