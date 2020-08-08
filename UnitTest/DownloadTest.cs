using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Xunit;
using Example.FileToBite;
using Moq;
using Moq.Protected;

using FluentAssertions;

namespace UnitTest
{
    public class DownloadTest
    {
        [Fact]
        public async Task DownloadDataAsync()
        {
            var content = "[{'id':1,'value':'1'}]";

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               ).ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(content),
               }).Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            var download = new Download(httpClient);
            var result = await download.DownloadDataAsync("http://test.com/");
            Stream stream = new MemoryStream(result);
            StreamReader streamReader = new StreamReader(stream);
            streamReader.ReadToEnd().Should().BeEquivalentTo(content);
        }
    }
}
