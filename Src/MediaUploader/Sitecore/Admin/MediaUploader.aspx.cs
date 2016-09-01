using System;
using Sitecore.sitecore.admin;
using Sitecore.SharedSource.MediaUploader.Presenters;
using Sitecore.SharedSource.MediaUploader.Views;

namespace Sitecore.SharedSource.MediaUploader.Sitecore.Admin
{
    public partial class MediaUploader : AdminPage, IMediaUploaderView
    {
        private MediaUploaderPresenter _presenter;

        protected override void OnInit(EventArgs args)
        {
            this.CheckSecurity(true);
            base.OnInit(args);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialize the presenter
            this._presenter = new MediaUploaderPresenter(this);

            if (!this.IsPostBack)
            {
                this._presenter.Initialize();
            }
        }
    }
}