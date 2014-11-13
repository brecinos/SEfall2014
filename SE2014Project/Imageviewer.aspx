<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imageviewer.aspx.cs" Inherits="SE2014Project.Imageviewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body  style="background-color: #e2e2e2" >
    <form id="form1" runat="server">
    <div>
    
    </div>
        
            <h1>Here is the map to your classroom:</h1>

        <input type="button" value ="-" onclick="zoom(0.9)"/>
        <input type="button" value ="+" onclick="zoom(1.1)"/>
        

        <h1>Here is the path you have to take!</h1>

        <div id="thediv">
       <img src="MapCreator.aspx" width="1000px" height="1000px" />
     <asp:Button ID="ButtonZoomIn" runat="server" Text="+" OnClick="ButtonZoomIn_Click" />
    <asp:Button ID="ButtonZoomOut" runat="server" Text="-" />
     </div>

    </form>
    
  
</body>
</html>
