using System;
using System.Linq;
using System.Web.UI.WebControls;
using Sitecore.SharedSource.MediaUploader.Services;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Presenters
{
    public class MediaUploaderBlobListPresenter
    {
        private readonly IMediaUploaderBlobListView _view;
        private readonly MediaUploaderBlobListService _service;

        public MediaUploaderBlobListPresenter(IMediaUploaderBlobListView view, MediaUploaderBlobListService service)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (service == null) throw new ArgumentNullException(nameof(service));

            this._view = view;
            this._service = service;
        }

        public void GetBlobs(string searchPrefix)
        {
            // Assign the listing of the current blobs
            this._view.Blobs = this._service.GetBlobs(searchPrefix);

            this._view.DataBind();
        }

        public void OnItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeleteBlob")
            {
                string blobName = e.CommandArgument.ToString();
                this._service.DeleteBlob(blobName);
                this._view.Blobs = this._view.Blobs.Where(x => x.Name != blobName).ToList();
                this._view.DataBind();
            }
        }
    }
}