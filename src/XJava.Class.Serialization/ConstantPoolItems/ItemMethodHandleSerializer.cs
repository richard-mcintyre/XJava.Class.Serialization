using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemMethodHandleSerializer : ItemSerializerBase<ItemMethodHandle>
    {
        public override ItemMethodHandle Deserialize(BigEndianBinaryReader reader)
        {
            ReferenceKind kind = (ReferenceKind)reader.ReadByte();
            ushort index = reader.ReadUInt16();
            return new ItemMethodHandle(kind, index);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemMethodHandle item)
        {
            writer.WriteByte((byte)item.ReferenceKind);
            writer.WriteUInt16(item.ReferenceIndex);
        }
    }
}
