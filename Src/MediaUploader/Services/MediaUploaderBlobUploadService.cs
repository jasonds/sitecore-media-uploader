using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using Sitecore.SharedSource.MediaUploader.Models;

namespace Sitecore.SharedSource.MediaUploader.Services
{
    public class MediaUploaderBlobUploadService : MediaUploaderBlobService
    {
        public void Upload(ICollection<BlobUpload> blobs)
        {
            try
            {
                CloudBlobContainer container = this.GetContainer();

                foreach (BlobUpload blobUpload in blobs)
                {
                    if (blobUpload.InputStream != null)
                    {
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobUpload.Name);

                        using (var fileStream = blobUpload.InputStream)
                        {
                            try
                            {
                                blockBlob.UploadFromStream(fileStream);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}