using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemDoubleSerializer : ItemSerializerBase<ItemDouble>
    {
        public override ItemDouble Deserialize(BigEndianBinaryReader reader)
        {
            double value = reader.ReadDouble();
            return new ItemDouble(value);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemDouble item) =>
            writer.WriteDouble(item.Value);
    }
}
