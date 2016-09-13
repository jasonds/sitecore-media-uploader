using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.MediaUploader.Models;
using Sitecore.SharedSource.MediaUploader.Services;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Presenters
{
    internal class MediaUploaderBlobUploadPresenter
    {
        private readonly IMediaUploaderBlobUploadView _view;
        private readonly MediaUploaderBlobUploadService _service;

        public MediaUploaderBlobUploadPresenter(IMediaUploaderBlobUploadView view, MediaUploaderBlobUploadService service)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (service == null) throw new ArgumentNullException(nameof(service));

            this._view = view;
            this._service = service;
        }

        public void UploadBlobs(HttpFileCollection files)
        {
            if (files != null && files.Count > 0)
            {
                List<BlobUpload> blobs = new List<BlobUpload>();
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile postedFile = files[i];
                    HttpPostedFileBase file = new HttpPostedFileWrapper(postedFile);

                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        string name = Path.GetFileName(file.FileName);

                        blobs.Add(new BlobUpload
                        {
                            Name = string.Format("{0}_{1}_{2}", DateTime.Now.ToString("yyyyMMdd_HHmmss"), name, Guid.NewGuid()),
                            FilePath = file.FileName,
                            InputStream = file.InputStream
                        });
                    }
                }

                // Upload blobs if necessary
                if (blobs.Any())
                {
                    this._service.Upload(blobs);
                }
            }

            this._view.OnBlobsUploaded();
        }
    }
}