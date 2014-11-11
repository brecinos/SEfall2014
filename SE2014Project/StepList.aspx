<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StepList.aspx.cs" Inherits="SE2014Project.StepList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
h1 {
    color:blue;
    font-family:verdana;
    font-size:300%;
}
p  {
    color:red;
    font-family:courier;
    font-size:160%;
}
</style>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3> Here's the list of steps to take from your current room to your destination </h3>
    </div>
        <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-BackColor="#99ccff" BorderColor="#00ffcc" HeaderStyle-BackColor="#33ccff"></asp:GridView>
    </form>
</body>
</html>
