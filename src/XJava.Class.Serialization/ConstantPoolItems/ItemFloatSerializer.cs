using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemFloatSerializer : ItemSerializerBase<ItemFloat>
    {
        public override ItemFloat Deserialize(BigEndianBinaryReader reader)
        {
            float value = reader.ReadSingle();
            return new ItemFloat(value);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemFloat item) =>
            writer.WriteSingle(item.Value);
    }
}
