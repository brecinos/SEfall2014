<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Imageviewer.aspx.cs" Inherits="SE2014Project.Imageviewer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>

              <asp:Button ID="ButtonZoomIn" runat="server" Text="+" OnClick="ButtonZoomIn_Click" />
    <asp:Button ID="ButtonZoomOut" runat="server" Text="-" OnClick="ButtonZoomOut_Click" />

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
       <ContentTemplate>
            <h1>Here is the map to your classroom:</h1>

        <div id="thediv">
            <asp:Image ID="imgMap" runat="server" />
     </div>
       </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ButtonZoomIn" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ButtonZoomOut" EventName="Click" />
       </Triggers>

        </asp:UpdatePanel>
    </div>
 </asp:Content>
