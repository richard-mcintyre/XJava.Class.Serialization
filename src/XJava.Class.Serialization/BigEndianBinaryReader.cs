using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization
{
    internal class BigEndianBinaryReader : IDisposable
    {
        #region Construction

        public BigEndianBinaryReader(Stream stream)
            : this(stream, false)
        {
        }

        public BigEndianBinaryReader(Stream stream, bool leaveOpen)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;
        }

        ~BigEndianBinaryReader() =>
            Dispose(false);

        #endregion

        #region Fields

        private readonly Stream _stream;
        private readonly bool _leaveOpen;
        private readonly byte[] _buffer = new byte[16];

        #endregion

        #region Methods

        public byte ReadByte()
        {
            int val = _stream.ReadByte();
            if(val == -1)
                throw new EndOfStreamException();

            return (byte)val;
        }

        public byte[] ReadBytes(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 0)
                return Array.Empty<byte>();

            byte[] result = new byte[count];
            _stream.ReadExactly(result, 0, result.Length);

            return result;
        }

        public void SkipBytes(uint count)
        {
            if (count < 0 || count > Int32.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_stream.CanSeek)
            {
                _stream.Seek(count, SeekOrigin.Current);
            }
            else
            {
                ReadBytes((int)count);
            }
        }

        public ushort ReadUInt16() =>
            BinaryPrimitives.ReadUInt16BigEndian(InternalRead(2));

        public uint ReadUInt32() => 
            BinaryPrimitives.ReadUInt32BigEndian(InternalRead(4));

        public int ReadInt32() =>
            BinaryPrimitives.ReadInt32BigEndian(InternalRead(4));

        public long ReadInt64() =>
            BinaryPrimitives.ReadInt64BigEndian(InternalRead(8));

        public float ReadSingle() =>
            BinaryPrimitives.ReadSingleBigEndian(InternalRead(4));

        public double ReadDouble() =>
            BinaryPrimitives.ReadDoubleBigEndian(InternalRead(8));

        private ReadOnlySpan<byte> InternalRead(int count)
        {
            Debug.Assert(count != 1, "Use ReadByte to read a single byte");
            Debug.Assert(count <= _buffer.Length, $"{nameof(count)} exceeds buffer size");

            _stream.ReadExactly(_buffer.AsSpan(0, count));

            return _buffer;
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
