using System.Reflection.PortableExecutable;
using XJava.Class.Serialization.ConstantPoolItems;

namespace XJava.Class.Serialization.Tests;

public class ConstantPoolDefinitionTests
{
    private ConstantPoolDefinition _poolFromFile = new ConstantPoolDefinition();
    private ConstantPoolDefinition _newPool = new ConstantPoolDefinition();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Stream stream = File.OpenRead(@"..\..\..\TestClassFiles\ConstantPoolTest.class");
        stream.Seek(8, SeekOrigin.Begin);   // Move to the start of the constant pool

        _poolFromFile = ConstantPoolDefinition.Deserialize(stream);
    }

    [SetUp]
    public void SetUp()
    {
        _newPool = new ConstantPoolDefinition();
    }

    [Test, Sequential]
    public void ReadUtf8(
        [Values(4, 5, 6, 112)] int index, 
        [Values("java/lang/Object", "<init>", "()V", "Lookup")] string expectedValue)
    {
        var item = _poolFromFile.GetItem<ItemUtf8>(index);
        Assert.That(item.Value, Is.EqualTo(expectedValue));
    }

    [Test, Sequential]
    public void ReadInteger(
        [Values(7, 14)] int index,
        [Values(-2147483648, 2147483647)] int expectedValue)
    {
        var item = _poolFromFile.GetItem<ItemInteger>(index);
        Assert.That(item.Value, Is.EqualTo(expectedValue));
    }

    [Test, Sequential]
    public void ReadFloat(
        [Values(29)] int index,
        [Values(123.45f)] float expectedValue)
    {
        var item = _poolFromFile.GetItem<ItemFloat>(index);
        Assert.That(item.Value, Is.EqualTo(expectedValue));
    }

    [Test, Sequential]
    public void ReadLong(
        [Values(18, 24)] int index,
        [Values(-9223372036854775808L, 9223372036854775807L)] long expectedValue)
    {
        var item = _poolFromFile.GetItem<ItemLong>(index);
        Assert.That(item.Value, Is.EqualTo(expectedValue));
    }

    [Test, Sequential]
    public void ReadDouble(
        [Values(34)] int index,
        [Values(456.78d)] double expectedValue)
    {
        var item = _poolFromFile.GetItem<ItemDouble>(index);
        Assert.That(item.Value, Is.EqualTo(expectedValue));
    }

    [Test, Sequential]
    public void ReadClass(
        [Values(2, 9, 110)] int index,
        [Values((ushort)4, (ushort)11, (ushort)111)] ushort expectedNameIndex)
    {
        var item = _poolFromFile.GetItem<ItemClass>(index);
        Assert.That(item.NameIndex, Is.EqualTo(expectedNameIndex));
    }

    [Test, Sequential]
    public void ReadString(
        [Values(69)] int index,
        [Values((ushort)70)] ushort expectedStringIndex)
    {
        var item = _poolFromFile.GetItem<ItemString>(index);
        Assert.That(item.StringIndex, Is.EqualTo(expectedStringIndex));
    }

    [Test, Sequential]
    public void ReadFieldRef(
        [Values(8, 15, 63)] int index,
        [Values((ushort)9, (ushort)9, (ushort)64)] ushort expectedClassIndex,
        [Values((ushort)10, (ushort)16, (ushort)65)] ushort expectedNameAndTypeIndex)
    {
        var item = _poolFromFile.GetItem<ItemFieldRef>(index);
        Assert.That(item.ClassIndex, Is.EqualTo(expectedClassIndex));
        Assert.That(item.NameAndTypeIndex, Is.EqualTo(expectedNameAndTypeIndex));
    }

    [Test, Sequential]
    public void ReadMethodRef(
        [Values(1, 42, 104)] int index,
        [Values((ushort)2, (ushort)40, (ushort)9)] ushort expectedClassIndex,
        [Values((ushort)3, (ushort)3, (ushort)105)] ushort expectedNameAndTypeIndex)
    {
        var item = _poolFromFile.GetItem<ItemMethodRef>(index);
        Assert.That(item.ClassIndex, Is.EqualTo(expectedClassIndex));
        Assert.That(item.NameAndTypeIndex, Is.EqualTo(expectedNameAndTypeIndex));
    }

    [Test, Sequential]
    public void ReadInterfaceMethodRef(
        [Values(58)] int index,
        [Values((ushort)59)] ushort expectedClassIndex,
        [Values((ushort)60)] ushort expectedNameAndTypeIndex)
    {
        var item = _poolFromFile.GetItem<ItemInterfaceMethodRef>(index);
        Assert.That(item.ClassIndex, Is.EqualTo(expectedClassIndex));
        Assert.That(item.NameAndTypeIndex, Is.EqualTo(expectedNameAndTypeIndex));
    }

    [Test, Sequential]
    public void ReadNameAndType(
        [Values(3, 10, 105)] int index,
        [Values((ushort)5, (ushort)12, (ushort)90)] ushort expectedNameIndex,
        [Values((ushort)6, (ushort)13, (ushort)6)] ushort expectedDescriptorIndex)
    {
        var item = _poolFromFile.GetItem<ItemNameAndType>(index);
        Assert.That(item.NameIndex, Is.EqualTo(expectedNameIndex));
        Assert.That(item.DescriptorIndex, Is.EqualTo(expectedDescriptorIndex));
    }

    [Test, Sequential]
    public void ReadMethodHandle(
        [Values(95, 103)] int index,
        [Values((byte)ReferenceKind.InvokeStatic, (byte)ReferenceKind.InvokeStatic)] byte expectedRefKind,
        [Values((ushort)96, (ushort)104)] ushort expectedRefIndex)
    {
        var item = _poolFromFile.GetItem<ItemMethodHandle>(index);
        Assert.That(item.ReferenceKind, Is.EqualTo((ReferenceKind)expectedRefKind));
        Assert.That(item.ReferenceIndex, Is.EqualTo(expectedRefIndex));
    }

    [Test, Sequential]
    public void ReadMethodType(
        [Values(102)] int index,
        [Values((ushort)6)] ushort expectedDescriptorIndex)
    {
        var item = _poolFromFile.GetItem<ItemMethodType>(index);
        Assert.That(item.DescriptorIndex, Is.EqualTo(expectedDescriptorIndex));
    }

    [Test, Sequential]
    public void ReadInvokeDynamic(
        [Values(43)] int index,
        [Values((ushort)0)] ushort expectedMethodAttribIndex,
        [Values((ushort)44)] ushort expectedNameAndTypeIndex)
    {
        var item = _poolFromFile.GetItem<ItemInvokeDynamic>(index);
        Assert.That(item.BootstrapMethodAttributeIndex, Is.EqualTo(expectedMethodAttribIndex));
        Assert.That(item.NameAndTypeIndex, Is.EqualTo(expectedNameAndTypeIndex));
    }

    [Test]
    public void WriteUtf8() =>
        WriteItem(new ItemUtf8("test value"));

    [Test]
    public void WriteInteger() =>
        WriteItem(new ItemInteger(-1528375691));

    [Test]
    public void WriteFloat() =>
        WriteItem(new ItemFloat(123.45f));

    [Test]
    public void WriteLong() =>
        WriteItem(new ItemLong(-753810920750384729L));

    [Test]
    public void WriteDouble() =>
        WriteItem(new ItemDouble(456.78d));

    [Test]
    public void WriteClass() =>
        WriteItem(new ItemClass(1234));

    [Test]
    public void WriteString() =>
        WriteItem(new ItemString(1234));

    [Test]
    public void WriteFieldRef() =>
        WriteItem(new ItemFieldRef(1234, 5678));

    [Test]
    public void WriteMethodRef() =>
        WriteItem(new ItemMethodRef(1234, 5678));

    [Test]
    public void WriteInterfaceMethodRef() =>
        WriteItem(new ItemInterfaceMethodRef(1234, 5678));

    [Test]
    public void WriteNameAndType() =>
        WriteItem(new ItemNameAndType(1234, 5678));

    [Test]
    public void WriteMethodHandle() =>
        WriteItem(new ItemMethodHandle(ReferenceKind.InvokeSpecial, 1234));

    [Test]
    public void WriteMethodType() =>
        WriteItem(new ItemMethodType(1234));

    [Test]
    public void WriteInvokeDynamic() =>
        WriteItem(new ItemInvokeDynamic(1234, 5678));

    private void WriteItem<T>(T expected)
        where T : IItem
    {
        var actual = WriteAndReadBackItem(expected);
        Assert.That(actual, Is.EqualTo(expected));
    }

    private T WriteAndReadBackItem<T>(T actual)
        where T : IItem
    {
        int index = _newPool.AddItem(actual);

        using (MemoryStream stream = new MemoryStream())
        {
            _newPool.Serialize(stream);

            stream.Seek(0, SeekOrigin.Begin);

            ConstantPoolDefinition read = ConstantPoolDefinition.Deserialize(stream);
            return read.GetItem<T>(index);
        }
    }

}
