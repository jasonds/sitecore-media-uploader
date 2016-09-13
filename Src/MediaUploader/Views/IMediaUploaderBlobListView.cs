using System.Collections.Generic;
using Sitecore.SharedSource.MediaUploader.Models;

namespace Sitecore.SharedSource.MediaUploader.Views
{
    public interface IMediaUploaderBlobListView
    {
        ICollection<Blob> Blobs { get; set; }

        string SearchPrefix { get; }

        void DataBind();
    }
}
