using System.IO;

namespace Sitecore.SharedSource.MediaUploader.Models
{
    public class BlobUpload : Blob
    {
        public string FilePath { get; set; }

        public Stream InputStream { get; set; }
    }
}
