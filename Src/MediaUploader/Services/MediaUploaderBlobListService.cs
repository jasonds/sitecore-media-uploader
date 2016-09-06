using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Blob;
using Sitecore.SharedSource.MediaUploader.Models;

namespace Sitecore.SharedSource.MediaUploader.Services
{
    public class MediaUploaderBlobListService : MediaUploaderBlobService
    {
        public ICollection<Blob> GetBlobs(string searchPrefix)
        {
            List<Blob> results = new List<Blob>();

            try
            {
                CloudBlobContainer container = this.GetContainer();
                var response = container.ListBlobsSegmented(searchPrefix, false, BlobListingDetails.None, 100, null, null, null);
                results.AddRange(response.Results.Select(x =>
                {
                    CloudBlockBlob cloudBlockBlob = (CloudBlockBlob)x;
                    return new Blob
                    {
                        Name = cloudBlockBlob.Name,
                        StorageEndpoint = cloudBlockBlob.Uri.ToString(),
                        CdnEndpoint = string.Format("{0}/{1}", this.AzureCdnEndpoint, cloudBlockBlob.Name)
                    };
                }));
            }
            catch (Exception)
            {
                // ignored
            }

            return results;
        }

        public void DeleteBlob(string blobName)
        {
            try
            {
                CloudBlobContainer container = this.GetContainer();
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                blockBlob.Delete();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}