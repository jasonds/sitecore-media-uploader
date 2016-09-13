<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobUpload.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobUpload" %>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-md-3">
            <asp:FileUpload runat="server" ID="fuBlobs" CssClass="btn btn-default upload-disable" AllowMultiple="true" />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-primary upload-disable" OnClientClick="sc.mediauploader.onUpload()" UseSubmitBehavior="false" Text="Upload Files" />
        </div>
    </div>
    <div runat="server" ID="imgUploadLoadingIndicatorContainer" class="loading-indicator-container">
        <img runat="server" ID="imgUploadLoadingIndicator" src="/Sitecore/Admin/Assets/Local/Images/loading_spinner.gif" class="loading-indicator" />
    </div>
</div>