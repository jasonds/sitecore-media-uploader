<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaUploaderBlobList.ascx.cs" Inherits="Sitecore.SharedSource.MediaUploader.Sitecore.Admin.UserControls.MediaUploaderBlobList" %>

<div class="container-fluid">
    <div class="row margin-bottom-md">
        <div class="col-md-3">
            <asp:TextBox runat="server" ID="tbSearchPrefix" Placeholder="Search Prefix" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Button runat="server" ID="btnSearchSubmit" CssClass="btn btn-primary" Text="Submit" />
        </div>
    </div>
    
    <div class="row margin-bottom-md">
        <div class="col-md-1">
        </div>
        <div class="col-md-3">
            <h4>Name</h4>
        </div>
        <div class="col-md-4">
            <h4>CDN Endpoint</h4>
        </div>
        <div class="col-md-4">
            <h4>Storage Endpoint</h4>
        </div>
    </div>

    <asp:Repeater runat="server" ID="rptBlobList" ItemType="Sitecore.SharedSource.MediaUploader.Models.Blob">
        <ItemTemplate>
            <div class="row margin-bottom-md">
                <div class="col-md-1">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-danger" OnClientClick="javascript:if(!confirm('Delete this blob?'))return false;" CommandName="DeleteBlob" CommandArgument='<%# Eval("Name") %>' />
                </div>
                <div class="col-md-3"><%# Item.Name %></div>
                <div class="col-md-4"><%# Item.CdnEndpoint %></div>
                <div class="col-md-4"><%# Item.StorageEndpoint %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>