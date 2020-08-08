using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Example.FileToBite
{
    public class Download : IDownload
    {
        private readonly HttpClient _httpClient;
        public Download(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<byte[]> DownloadDataAsync(string url)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await _httpClient.SendAsync(request);

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return contentStream.ReadAllBytes();
        }
    }
}