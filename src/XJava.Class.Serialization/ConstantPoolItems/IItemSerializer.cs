using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal interface IItemSerializer
    {
        IItem Deserialize(BigEndianBinaryReader reader);

        void Serialize(BigEndianBinaryWriter writer, IItem item);
    }

    internal interface IItemSerializer<T> : IItemSerializer
        where T : IItem
    {
        new T Deserialize(BigEndianBinaryReader reader);

        void Serialize(BigEndianBinaryWriter writer, T item);
    }
}
