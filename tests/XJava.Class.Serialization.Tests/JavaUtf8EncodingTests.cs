using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJava.Class.Serialization.Tests
{
    public class JavaUtf8EncodingTests
    {
        private readonly Encoding _encoding = new JavaUtf8Encoding();

        [Test]
        public void DecodeMultipleChars()
        {
            byte[] bytes = new byte[]
            {
                0x3e,       // >
                0x61,       // a
                0x2c,       // ,
                0xc0, 0x80, // null
                0x2c,       // ,
                0xc2, 0x80, // u0080
                0x2c,       // ,
                0xdf, 0xbf, // u07ff
                0x2c,       // ,
                0xe0, 0xa0, 0x80, // u0800
                0x2c,       // ,
                0xef, 0xbf, 0xbf, // uffff
                0x2c,       // ,
                0xed, 0xa0, 0xbd, 0xed, 0xb9, 0x8f,     // \u1F64F
                0x3c,       // <
            };

            string actual = _encoding.GetString(bytes);
            Assert.That(actual, Is.EqualTo(">a,\0,\u0080,\u07ff,\u0800,\uffff,🙏<"));
        }

        [Test]
        public void DecodeSingleByte()
        {
            string actual = _encoding.GetString(new byte[] { 0x61 });
            Assert.That(actual, Is.EqualTo("a"));
        }

        [Test]
        public void DecodeNull()
        {
            string actual = _encoding.GetString(new byte[] { 0xc0, 0x80 });
            Assert.That(actual, Is.EqualTo("\0"));
        }

        [Test]
        public void Decode2Bytes_u0080()
        {
            string actual = _encoding.GetString(new byte[] { 0xc2, 0x80 });
            Assert.That(actual, Is.EqualTo("\u0080"));
        }

        [Test]
        public void Decode2Bytes_u07ff()
        {
            string actual = _encoding.GetString(new byte[] { 0xdf, 0xbf });
            Assert.That(actual, Is.EqualTo("\u07ff"));
        }

        [Test]
        public void Decode3Bytes_u0800()
        {
            string actual = _encoding.GetString(new byte[] { 0xe0, 0xa0, 0x80 });
            Assert.That(actual, Is.EqualTo("\u0800"));
        }

        [Test]
        public void Decode3Bytes_uffff()
        {
            string actual = _encoding.GetString(new byte[] { 0xef, 0xbf, 0xbf });
            Assert.That(actual, Is.EqualTo("\uffff"));
        }

        [Test]
        public void Decode6Bytes_u1F64F()
        {
            string actual = _encoding.GetString(new byte[] { 0xed, 0xa0, 0xbd, 0xed, 0xb9, 0x8f });
            Assert.That(actual, Is.EqualTo("\ud83d\ude4f"));
        }

        [Test]
        public void EncodeSingleByte()
        {
            byte[] actual = _encoding.GetBytes("a");
            Assert.That(actual, Is.EqualTo(new byte[] { 0x61 }));
        }

        [Test]
        public void EncodeNull()
        {
            byte[] actual = _encoding.GetBytes("\0");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xc0, 0x80 }));
        }

        [Test]
        public void Encode2Bytes_u0080()
        {
            byte[] actual = _encoding.GetBytes("\u0080");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xc2, 0x80 }));
        }

        [Test]
        public void Encode2Bytes_u07ff()
        {
            byte[] actual = _encoding.GetBytes("\u07ff");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xdf, 0xbf }));
        }

        [Test]
        public void Encode3Bytes_u0800()
        {
            byte[] actual = _encoding.GetBytes("\u0800");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xe0, 0xa0, 0x80 }));
        }

        [Test]
        public void Encode3Bytes_uffff()
        {
            byte[] actual = _encoding.GetBytes("\uffff");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xef, 0xbf, 0xbf }));
        }

        [Test]
        public void Encode6Bytes_u1F64F()
        {
            byte[] actual = _encoding.GetBytes("\ud83d\ude4f");
            Assert.That(actual, Is.EqualTo(new byte[] { 0xed, 0xa0, 0xbd, 0xed, 0xb9, 0x8f }));
        }
    }
}
