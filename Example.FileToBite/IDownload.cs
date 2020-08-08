using System.Threading.Tasks;

namespace Example.FileToBite
{
    public interface IDownload
    {
        Task<byte[]> DownloadDataAsync(string url);
    }
}