<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobUpload.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobUpload" %>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-md-3">
            <asp:FileUpload runat="server" ID="fuBlobs" AllowMultiple="true"  />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-primary" Text="Upload Files" />
        </div>
    </div>
</div>