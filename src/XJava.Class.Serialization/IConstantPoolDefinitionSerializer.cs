using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJava.Class.Serialization.ConstantPoolItems;

namespace XJava.Class.Serialization
{
    internal interface IConstantPoolDefinitionSerializer
    {
        IEnumerable<IItem> Deserialize(Stream stream);

        void Serialize(Stream stream, IEnumerable<IItem> items);
    }
}
