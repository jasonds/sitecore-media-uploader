using System;
using System.Collections.Generic;
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

        public void GetBlobs()
        {
            this._view.Blobs = this._service.GetBlobs(this._view.SearchPrefix);

            this._view.DataBind();
        }

        public void DeleteMultipleBlobs(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var rptBlobList = (Repeater)button.FindControl("rptBlobList");

            List<string> blobNames = new List<string>();
            foreach (RepeaterItem repeaterItem in rptBlobList.Items)
            {
                CheckBox cb = (CheckBox)repeaterItem.FindControl("cbSelectRow");
                if (cb.Checked)
                {
                    string blobName = this.GetBlobName(repeaterItem);
                    blobNames.Add(blobName);
                }
            }

            this._service.DeleteMultipleBlobs(blobNames);

            this.GetBlobs();
        }

        public void OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteBlob":
                {
                    string blobName = this.GetBlobName(e.Item);
                    this._service.DeleteBlob(blobName);
                    this.GetBlobs();
                    return;
                }
            }
        }

        public void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = e.Item.FindControl("btnView") as Button;
                if (btn != null)
                {
                    btn.OnClientClick = string.Format("javascript:return sc.mediauploader.onViewDetails('{0}');", btn.CommandArgument);
                }
            }
        }

        private string GetBlobName(RepeaterItem repeaterItem)
        {
            HiddenField hf = (HiddenField)repeaterItem.FindControl("hfBlobName");
            return hf.Value;
        }
    }
}