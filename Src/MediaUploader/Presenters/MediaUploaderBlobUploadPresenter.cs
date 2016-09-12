using System;
using System.Collections.Generic;
using System.IO;
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
                    string name = Path.GetFileName(file.FileName);
                    blobs.Add(new BlobUpload
                    {
                        Name = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd_HHmmss_fff"), name),
                        FilePath = file.FileName,
                        InputStream = file.InputStream
                    });
                }

                this._service.Upload(blobs);
            }

            this._view.OnBlobsUploaded();
        }
    }
}