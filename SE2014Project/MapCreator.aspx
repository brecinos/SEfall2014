<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapCreator.aspx.cs" Inherits="SE2014Project.MapCreator" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Text" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>

<%
    
	%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  



</head>
<body >
       

    <form id="Form1" runat="server">
    <asp:Button ID="ButtonZoomIn" runat="server" Text="+" OnClick="ButtonZoomIn_Click" />
    <asp:Button ID="ButtonZoomOut" runat="server" Text="-" OnClick="ButtonZoomOut_Click" />
 </form>

</body>
</html>
