using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EarthWallpaper.Contracts
{
    public interface IDownloadService
    {
        Task<byte[]> Get(string address);
        Task<string> Get(string address, string filename);
        Task<byte[]> Get(string address, Dictionary<string, IEnumerable<string>> headers);
        Task<byte[]> Post(string address, string content);
        Task<byte[]> Post(string address, string content, Dictionary<string, IEnumerable<string>> headers);
    }
}
