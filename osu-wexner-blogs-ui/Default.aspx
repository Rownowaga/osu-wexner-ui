<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="osu_wexner_blogs_ui.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <asp:Label ID="lblFilter" runat="server" Text="Filter Blogs by Title:"></asp:Label>
            <asp:DropDownList ID="ddlBlogTitles" runat="server" OnSelectedIndexChanged="filterBlogDetails"></asp:DropDownList>
    </div>
</asp:Content>
