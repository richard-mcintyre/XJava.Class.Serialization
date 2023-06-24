using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemIntegerSerializer : ItemSerializerBase<ItemInteger>
    {
        public override ItemInteger Deserialize(BigEndianBinaryReader reader)
        {
            int value = reader.ReadInt32();
            return new ItemInteger(value);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemInteger item) =>
            writer.WriteInt32(item.Value);
    }
}
