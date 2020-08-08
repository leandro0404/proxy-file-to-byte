using System.IO;
using System.Text;
using Xunit;
using Example.FileToBite;
using FluentAssertions;

namespace UnitTest
{
    public class StreamExtensionsTest
    {
        [Fact]
        public void ReadAllBytes()
        {
            Stream actual = new MemoryStream(Encoding.UTF8.GetBytes("whatever"));
            var result = actual.ReadAllBytes();
            Stream expected = new MemoryStream(result);

            StreamReader readerActual = new StreamReader(actual);
            StreamReader readerExpected = new StreamReader(expected);
            readerActual.ReadToEnd().Should().BeEquivalentTo(readerExpected.ReadToEnd());
        }
    }
}
