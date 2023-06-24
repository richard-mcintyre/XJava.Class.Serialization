using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal class ItemInvokeDynamicSerializer : ItemSerializerBase<ItemInvokeDynamic>
    {
        public override ItemInvokeDynamic Deserialize(BigEndianBinaryReader reader)
        {
            ushort boostrapMethodAttribIndex = reader.ReadUInt16();
            ushort nameAndTypeIndex = reader.ReadUInt16();
            return new ItemInvokeDynamic(boostrapMethodAttribIndex, nameAndTypeIndex);
        }

        public override void Serialize(BigEndianBinaryWriter writer, ItemInvokeDynamic item)
        {
            writer.WriteUInt16(item.BootstrapMethodAttributeIndex);
            writer.WriteUInt16(item.NameAndTypeIndex);
        }
    }
}
