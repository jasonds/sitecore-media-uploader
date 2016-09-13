<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobList.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobList" %>
<%@ Import Namespace="Sitecore.SharedSource.MediaUploader.Models" %>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-xs-6">
            <asp:TextBox ID="tbSearchPrefix" runat="server" Placeholder="Search Prefix (first 100 Results shown)" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-1">
            <asp:Button ID="btnSearchSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
        </div>
        <div class="col-xs-5">
            <div class="btn-group pull-right">
                <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected" CssClass="btn btn-danger" OnClientClick="return sc.mediauploader.onDeleteAll();" CommandName="DeleteMultipleBlobs" />
            </div>
        </div>
    </div>
    
    <hr />
    
    <div class="row margin-bottom-md">
        <div class="col-md-1">
            <h4>Index <asp:CheckBox ID="cbSelectAll" runat="server" /></h4>
        </div>
        <div class="col-md-2">
            <h4>Actions</h4>
        </div>
        <div class="col-md-4">
            <h4>Name</h4>
        </div>
        <div class="col-md-5">
            <h4>CDN Endpoint</h4>
        </div>
    </div>

    <asp:Repeater ID="rptBlobList" runat="server" ItemType="Sitecore.SharedSource.MediaUploader.Models.Blob">
        <ItemTemplate>
            <div class="row margin-bottom-md">
                <asp:HiddenField ID="hfBlobName" runat="server" Value="<%# Item.Name %>" />
                <div class="col-md-1">
                    <strong><%# Container.ItemIndex + 1 %>)</strong>
                    <asp:CheckBox ID="cbSelectRow" runat="server" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-primary" CommandName="ViewBlob" CommandArgument='<%# Newtonsoft.Json.JsonConvert.SerializeObject((Blob)Container.DataItem) %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return sc.mediauploader.onDelete();" CommandName="DeleteBlob" />
                </div>
                <div class="col-md-4">
                    <%# Item.Name %>
                </div>
                <div class="col-md-5">
                    <i class="fa fa-clipboard fa-2x clipboard" aria-hidden="true"></i>
                    <input type="text" readonly class="form-control" value="<%# Item.CdnEndpoint %>" />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

<div class="modal fade" id="blobDetailsModal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Blob Details</h4>
            </div>
            <div class="modal-body">
                <div class="row margin-bottom-md">
                    <div class="col-xs-12">
                        <h4>Name</h4>
                        <p id="blobDetailsContentName"></p>
                    </div>
                </div>
                <div class="row margin-bottom-md">
                    <div class="col-xs-12">
                        <h4>CDN Endpoint</h4>
                        <i class="fa fa-clipboard fa-2x clipboard" aria-hidden="true"></i>
                        <input type="text" readonly class="form-control" id="blobDetailsContentCdnEndpoint" />
                    </div>
                </div>
                <div class="row margin-bottom-md">
                    <div class="col-xs-12">
                        <h4>Storage Endpoint</h4>
                        <p id="blobDetailsContentStorageEndpoint"></p>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->