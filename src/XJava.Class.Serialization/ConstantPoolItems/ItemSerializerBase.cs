using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal abstract class ItemSerializerBase<T> : IItemSerializer<T>
        where T : IItem
    {
        public abstract T Deserialize(BigEndianBinaryReader reader);

        public abstract void Serialize(BigEndianBinaryWriter writer, T item);

        IItem IItemSerializer.Deserialize(BigEndianBinaryReader reader) =>
            Deserialize(reader);

        void IItemSerializer.Serialize(BigEndianBinaryWriter writer, IItem item) =>
            Serialize(writer, (T)item);
    }
}
