﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitialFrontal.aspx.cs" Inherits="SE2014Project.InitialFrontal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Table ID="Table1" runat="server" ForeColor="Red">
            
            <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Label"   ></asp:Label>

            </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell></asp:TableCell>

            </asp:TableRow>

        </asp:Table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="247px" Width="601px">
            <Columns>
                <asp:BoundField DataField="VertexName" HeaderText="Vertex" SortExpression="VertexName" />
                <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                </asp:ImageField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
