using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.MediaUploader.Services
{
    public abstract class MediaUploaderBlobService
    {
        protected readonly string AzureStorageConnectionString;
        protected readonly string AzureStorageEndpoint;
        protected readonly string AzureStorageContainerName;
        protected readonly string AzureCdnEndpoint;

        protected MediaUploaderBlobService()
        {
            // Retrieve Azure storage and cdn information
            this.AzureStorageConnectionString = Configuration.Settings.GetSetting(Constants.Settings.AzureStorageConnectionString);
            this.AzureStorageEndpoint = Configuration.Settings.GetSetting(Constants.Settings.AzureStorageEndpoint);
            this.AzureStorageContainerName = Configuration.Settings.GetSetting(Constants.Settings.AzureStorageContainerName);
            this.AzureCdnEndpoint = Configuration.Settings.GetSetting(Constants.Settings.AzureCdnEndpoint);
        }

        protected CloudBlobContainer GetContainer()
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.AzureStorageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(this.AzureStorageContainerName);
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

                return container;
            }
            catch (Exception ex)
            {
                Log.Error("Error creating blob container", ex);
                throw;
            }
        }
    }
}