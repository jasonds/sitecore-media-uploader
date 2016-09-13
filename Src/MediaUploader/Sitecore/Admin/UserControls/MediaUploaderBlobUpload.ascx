<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobUpload.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobUpload" %>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-md-3">
            <asp:FileUpload ID="fuBlobs" runat="server" AllowMultiple="true" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnUpload" runat="server" Text="Upload Files" CssClass="btn btn-primary" OnClientClick="return sc.mediauploader.onUpload()" />
        </div>
    </div>
</div>