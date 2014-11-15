<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="StepList.aspx.cs" Inherits="SE2014Project.StepList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3> Here's the list of steps to take from your current room to your destination </h3>
    </div>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AlternatingRowStyle-BackColor="#99ccff" BorderColor="#00ffcc" HeaderStyle-BackColor="#33ccff"></asp:GridView>

    </asp:Content>
