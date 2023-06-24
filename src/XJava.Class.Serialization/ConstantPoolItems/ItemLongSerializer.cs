using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemLongSerializer : ItemSerializerBase<ItemLong>
    {
        public override ItemLong Deserialize(BigEndianBinaryReader reader)
        {
            long value = reader.ReadInt64();
            return new ItemLong(value);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemLong item) =>
            writer.WriteInt64(item.Value);
    }
}
