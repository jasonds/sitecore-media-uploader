using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Sitecore.SharedSource.MediaUploader.Sitecore.Admin
{
    public partial class MediaUploader : Page
    {
        protected override void OnInit(EventArgs args)
        {
            this.CheckSecurity();
            base.OnInit(args);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Wire events
            this.ucMediaUploaderBlobUpload.BlobsUploaded += (sender, args) => this.ucMediaUploaderBlobList.Refresh();
        }

        private void CheckSecurity()
        {
            if (this.IsAdministrator() || this.IsDeveloper() || this.IsInCustomRole())
            {
                return;
            }

            HttpContext.Current.Response.Redirect(string.Format("{0}?returnUrl={1}", "/sitecore/login.aspx", HttpUtility.UrlEncode(this.Request.Url.PathAndQuery)));
        }

        private bool IsAdministrator()
        {
            return global::Sitecore.Context.User.IsAdministrator;
        }

        private bool IsDeveloper()
        {
            if (!this.User.IsInRole("sitecore\\developer"))
            {
                return this.User.IsInRole("sitecore\\sitecore client developing");
            }

            return true;
        }

        private bool IsInCustomRole()
        {
            string validRoles = Configuration.Settings.GetSetting(Constants.Settings.ValidRoles);
            if (!string.IsNullOrEmpty(validRoles))
            {
                // Attempt to split roles
                string[] roles = validRoles.Split(';');

                // Return true if the user is in any of the roles
                return roles.Any(x => this.User.IsInRole(x));
            }

            return true;
        }
    }
}