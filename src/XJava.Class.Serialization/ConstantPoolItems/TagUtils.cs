using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.ConstantPoolItems
{
    internal static class TagUtils
    {
        public static Tag GetTagForType<T>()
            where T : IItem
        {
            Type requestedType = typeof(T);

            if (requestedType == typeof(ItemUtf8))
                return Tag.Utf8;

            if (requestedType == typeof(ItemInteger))
                return Tag.Integer;

            if (requestedType == typeof(ItemFloat))
                return Tag.Float;

            if (requestedType == typeof(ItemLong))
                return Tag.Long;

            if (requestedType == typeof(ItemDouble))
                return Tag.Double;

            if (requestedType == typeof(ItemClass))
                return Tag.Class;

            if (requestedType == typeof(ItemString))
                return Tag.String;

            if (requestedType == typeof(ItemFieldRef))
                return Tag.FieldRef;

            if (requestedType == typeof(ItemMethodRef))
                return Tag.MethodRef;

            if (requestedType == typeof(ItemInterfaceMethodRef))
                return Tag.InterfaceMethodRef;

            if (requestedType == typeof(ItemNameAndType))
                return Tag.NameAndType;

            if (requestedType == typeof(ItemMethodHandle))
                return Tag.MethodHandle;

            if (requestedType == typeof(ItemMethodType))
                return Tag.MethodType;

            if (requestedType == typeof(ItemInvokeDynamic))
                return Tag.InvokeDynamic;

            throw new Exception($"Unknown constant pool item type {requestedType}");
        }
    }
}
