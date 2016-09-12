<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaUploader.aspx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.MediaUploader" %>

<%@ Register Src="~/Sitecore/Admin/UserControls/MediaUploaderBlobList.ascx" TagPrefix="uc" TagName="MediaUploaderBlobList" %>
<%@ Register Src="~/Sitecore/Admin/UserControls/MediaUploaderBlobUpload.ascx" TagPrefix="uc" TagName="MediaUploaderBlobUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Media Uploader</title>
    <link rel="stylesheet" href="//ajax.aspnetcdn.com/ajax/bootstrap/3.3.4/css/bootstrap.min.css" />
    <script src="//ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.4.min.js"></script>
    <script src="//ajax.aspnetcdn.com/ajax/bootstrap/3.3.4/bootstrap.min.js"></script>
    
    <style>
        .margin-bottom-md {
            margin-bottom: 20px;
        }

        .loading-indicator-container {
            display: none;
            text-align: center;
        }

        .loading-indicator-container.shown {
            display: block;
        }
        
        .loading-indicator {
            margin: 0 auto;
            max-width: 100px;
        }
    </style>
</head>
<body>
    <form id="mediaUploaderForm" runat="server">
        <h1>Media Uploader</h1>

        <div class="row">
            <div class="col-md-12">
                <ul class="nav nav-tabs margin-bottom-md" data-tabs="tabs" id="tabs" role="tablist">
                    <li class="active"><a href="#mediaUploaderBlobList" data-toggle="tab" role="tab">Blob List</a></li>
                    <li><a href="#mediaUploaderBlobUpload" data-toggle="tab" role="tab">Blob Upload</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="mediaUploaderBlobList">
                        <uc:MediaUploaderBlobList ID="ucMediaUploaderBlobList" runat="server" />
                    </div>
                    <div class="tab-pane" id="mediaUploaderBlobUpload">
                        <uc:MediaUploaderBlobUpload ID="ucMediaUploaderBlobUpload" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
