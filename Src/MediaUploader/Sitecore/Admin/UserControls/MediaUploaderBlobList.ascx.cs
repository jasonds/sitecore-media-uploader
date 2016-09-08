using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;
using Sitecore.SharedSource.MediaUploader.Models;
using Sitecore.SharedSource.MediaUploader.Presenters;
using Sitecore.SharedSource.MediaUploader.Services;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls
{
    public partial class MediaUploaderBlobList : UserControl, IMediaUploaderBlobListView
    {
        private MediaUploaderBlobListPresenter _presenter;

        public ICollection<Blob> Blobs
        {
            get
            {
                return (ICollection<Blob>)this.ViewState["Blobs"];
            }

            set
            {
                ICollection<Blob> result = new Collection<Blob>();
                if (value != null && value.Any())
                {
                    result = value;
                }

                this.ViewState["Blobs"] = result;
                this.rptBlobList.DataSource = result;
            }
        }

        public override void DataBind()
        {
            this.rptBlobList.DataBind();
            base.DataBind();
        }

        public void Refresh()
        {
            this._presenter.GetBlobs(this.tbSearchPrefix.Text);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialize the presenter
            this._presenter = new MediaUploaderBlobListPresenter(this, new MediaUploaderBlobListService());

            // Wire events
            this.btnSearchSubmit.Click += (sender, args) => { this._presenter.GetBlobs(this.tbSearchPrefix.Text); };
            this.rptBlobList.ItemCommand += (sender, args) => { this._presenter.OnItemCommand(sender, args); };

            if (!this.IsPostBack)
            {
                // Load initial data
                this._presenter.GetBlobs(this.tbSearchPrefix.Text);
            }
        }
    }
}