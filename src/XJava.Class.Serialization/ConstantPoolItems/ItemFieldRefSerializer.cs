using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemFieldRefSerializer : ItemSerializerBase<ItemFieldRef>
    {
        public override ItemFieldRef Deserialize(BigEndianBinaryReader reader)
        {
            ushort classIndex = reader.ReadUInt16();
            ushort nameAndTypeIndex = reader.ReadUInt16();
            return new ItemFieldRef(classIndex, nameAndTypeIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemFieldRef item)
        {
            writer.WriteUInt16(item.ClassIndex);
            writer.WriteUInt16(item.NameAndTypeIndex);
        }
    }
}
