<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="osu_wexner_blogs_ui.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="text-align:center;">
        <asp:Label ID="lblFilter" runat="server" Text="Filter Blogs by Topic:"></asp:Label>
        <asp:DropDownList ID="ddlBlogTitles" AutoPostBack="true" runat="server" OnSelectedIndexChanged="filterBlogDetails"></asp:DropDownList>
    </div>
    <br />
    <div>
        <asp:Literal runat="server" ID="litDetails"></asp:Literal>
        <asp:Label runat="server" ID="debugger" Text=""></asp:Label>
    </div>
    <script type="text/javascript">
    </script>
</asp:Content>
