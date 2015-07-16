using System;

namespace CKAN.NetKAN.Services
{
    internal sealed class CachingHttpService : IHttpService
    {
        private readonly NetFileCache _cache;

        public CachingHttpService(NetFileCache cache)
        {
            _cache = cache;
        }

        public string DownloadPackage(Uri url, string identifier)
        {
            return _cache.GetCachedFilename(url) ?? 
                _cache.Store(url, Net.Download(url), string.Format("netkan-{0}", identifier), move: true);
        }

        public string DownloadText(Uri url)
        {
            return Net.DownloadText(url);
        }
    }
}
