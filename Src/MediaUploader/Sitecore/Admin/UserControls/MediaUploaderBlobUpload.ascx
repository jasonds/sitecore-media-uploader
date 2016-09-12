<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobUpload.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobUpload" %>

<script>
    function onUpload() {
        var btnUpload = document.getElementById('<%=btnUpload.ClientID%>');
        btnUpload.disabled = true;

        var imgUploadLoadingIndicatorContainer = document.getElementById('<%=imgUploadLoadingIndicatorContainer.ClientID%>');
        imgUploadLoadingIndicatorContainer.className = 'loading-indicator-container shown';
    }
</script>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-md-3">
            <asp:FileUpload runat="server" ID="fuBlobs" AllowMultiple="true"  />
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-primary" OnClientClick="onUpload()" UseSubmitBehavior="false" Text="Upload Files" />
        </div>
    </div>
    <div runat="server" ID="imgUploadLoadingIndicatorContainer" class="loading-indicator-container">
        <img runat="server" ID="imgUploadLoadingIndicator" src="/Sitecore/Admin/Assets/loading_spinner.gif" class="loading-indicator" />
    </div>
</div>