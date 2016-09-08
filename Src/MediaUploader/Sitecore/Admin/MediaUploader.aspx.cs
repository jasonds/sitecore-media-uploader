using System;
using Sitecore.sitecore.admin;

namespace Sitecore.SharedSource.MediaUploader.Sitecore.Admin
{
    public partial class MediaUploader : AdminPage
    {
        protected override void OnInit(EventArgs args)
        {
            // this.CheckSecurity(true);
            base.OnInit(args);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Wire events
            this.ucMediaUploaderBlobUpload.BlobsUploaded += (sender, args) => this.ucMediaUploaderBlobList.Refresh();
        }
    }
}