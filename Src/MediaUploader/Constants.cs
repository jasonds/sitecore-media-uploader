﻿namespace Sitecore.SharedSource.MediaUploader
{
    public static class Constants
    {
        public static class Settings
        {
            public static readonly string AzureStorageConnectionString = string.Format("{0}AzureStorageConnectionString", Prefix);
            public static readonly string AzureStorageEndpoint = string.Format("{0}AzureStorageEndpoint", Prefix);
            public static readonly string AzureStorageContainerName = string.Format("{0}AzureStorageContainerName", Prefix);
            public static readonly string AzureCdnEndpoint = string.Format("{0}AzureCdnEndpoint", Prefix);
            public static readonly string ValidRoles = string.Format("{0}ValidRoles", Prefix);
            private const string Prefix = "MediaUploader.";
        }
    }
}