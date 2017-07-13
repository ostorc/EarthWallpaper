using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EarthWallpaper
{
    public class DownloadService : IDownloadService
    {
        public async Task<byte[]> Get(string address)
        {
            return await Get(address, new Dictionary<string, IEnumerable<string>>());
        }

        public async Task<string> Get(string address, string file)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, address))
            using (
                Stream contentStream = (client.SendAsync(request).GetAwaiter().GetResult()).Content.ReadAsStreamAsync().GetAwaiter().GetResult(),
                stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 3145728, true))
            {
                await contentStream.CopyToAsync(stream);
            }

            return file;
        }

        public async Task<byte[]> Get(string address, Dictionary<string, IEnumerable<string>> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, address);
                foreach (var item in headers)
                {
                    message.Headers.Add(item.Key, item.Value);
                }
                return await (await client.SendAsync(message)).Content.ReadAsByteArrayAsync();
            }
        }

        public async Task<byte[]> Post(string address, string content)
        {
            return await Post(address, content, new Dictionary<string, IEnumerable<string>>());
        }

        public async Task<byte[]> Post(string address, string content, Dictionary<string, IEnumerable<string>> headers)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, address);
                foreach (var item in headers)
                {
                    message.Headers.Add(item.Key, item.Value);
                }
                message.Content = new StringContent(content);
                return await (await client.SendAsync(message)).Content.ReadAsByteArrayAsync();
            }
        }
    }
}
