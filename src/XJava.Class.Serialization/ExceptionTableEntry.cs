using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization
{
    public record ExceptionTableEntry(ushort StartPC, ushort EndPC, ushort HandlerPC, string CatchType);
}
