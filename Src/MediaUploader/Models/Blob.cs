using System;

namespace Sitecore.SharedSource.MediaUploader.Models
{
    [Serializable]
    public class Blob
    {
        public string Name { get; set; }

        public string StorageEndpoint { get; set; }

        public string CdnEndpoint { get; set; }
    }
}
