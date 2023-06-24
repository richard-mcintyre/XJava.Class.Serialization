using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemUtf8Serializer : ItemSerializerBase<ItemUtf8>
    {
        private static Encoding _encoding = new JavaUtf8Encoding();

        public override ItemUtf8 Deserialize(BigEndianBinaryReader reader)
        {
            ushort length = reader.ReadUInt16();
            byte[] bytes = reader.ReadBytes(length);
            return new ItemUtf8(_encoding.GetString(bytes));
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemUtf8 item)
        {
            byte[] bytes = _encoding.GetBytes(item.Value);

            writer.WriteUInt16((ushort)bytes.Length);
            writer.WriteBytes(bytes);
        }
    }
}
