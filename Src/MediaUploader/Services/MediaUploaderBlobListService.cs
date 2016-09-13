using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Blob;
using Sitecore.Diagnostics;
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
            catch (Exception ex)
            {
                Log.Error("Error retrieving blobs", ex);
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
            catch (Exception ex)
            {
                Log.Error("Error deleting blob with name: " + blobName, ex);
            }
        }

        public void DeleteMultipleBlobs(List<string> blobNames)
        {
            try
            {
                CloudBlobContainer container = this.GetContainer();

                foreach (string blobName in blobNames)
                {
                    try
                    {
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                        blockBlob.Delete();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Error deleting blob with name: " + blobName, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error deleting multiple blobs", ex);
            }
        }
    }
}