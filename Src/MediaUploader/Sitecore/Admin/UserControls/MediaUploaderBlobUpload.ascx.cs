using System;
using System.Web.UI;
using Sitecore.SharedSource.MediaUploader.Presenters;
using Sitecore.SharedSource.MediaUploader.Services;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls
{
    public partial class MediaUploaderBlobUpload : UserControl, IMediaUploaderBlobUploadView
    {
        private MediaUploaderBlobUploadPresenter _presenter;

        public event EventHandler BlobsUploaded;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialize the presenter
            this._presenter = new MediaUploaderBlobUploadPresenter(this, new MediaUploaderBlobUploadService());

            // Wire events
            this.btnUpload.Click += (sender, args) => { this._presenter.UploadBlobs(Request.Files); };
        }

        public void OnBlobsUploaded()
        {
            if (this.BlobsUploaded != null)
            {
                this.BlobsUploaded(this, EventArgs.Empty);
            }
        }
    }
}