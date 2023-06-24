using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization
{
    internal class BigEndianBinaryWriter : IDisposable
    {
        #region Construction

        public BigEndianBinaryWriter(Stream stream)
            : this(stream, false)
        {
        }

        public BigEndianBinaryWriter(Stream stream, bool leaveOpen)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;
        }

        ~BigEndianBinaryWriter() =>
            Dispose(false);

        #endregion

        #region Fields

        private readonly Stream _stream;
        private readonly bool _leaveOpen;

        #endregion

        #region Methods

        public void WriteByte(byte value) =>
            _stream.WriteByte(value);

        public void WriteBytes(byte[] value) =>
            _stream.Write(value);

        public void WriteUInt16(ushort value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(ushort)];
            BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
            _stream.Write(buffer);
        }

        public void WriteInt32(int value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(int)];
            BinaryPrimitives.WriteInt32BigEndian(buffer, value);
            _stream.Write(buffer);
        }

        public void WriteInt64(long value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(long)];
            BinaryPrimitives.WriteInt64BigEndian(buffer, value);
            _stream.Write(buffer);
        }

        public void WriteSingle(float value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(float)];
            BinaryPrimitives.WriteSingleBigEndian(buffer, value);
            _stream.Write(buffer);
        }

        public void WriteDouble(double value)
        {
            Span<byte> buffer = stackalloc byte[sizeof(double)];
            BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
            _stream.Write(buffer);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_leaveOpen == false)
                    _stream?.Dispose();
            }
        }

        #endregion
    }
}
