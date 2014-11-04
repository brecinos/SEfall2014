<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitialFrontal.aspx.cs" Inherits="SE2014Project.InitialFrontal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script type="text/javascript">

        function check() {
            if (document.getElementById('TextBox1').value == ""
             || document.getElementById('TextBox1').value == undefined) {
                alert("Please Enter a Name");
                return false;
            }
            return true;
        }

        </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>

        <table>
            <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Where you are?" BackColor="#0066FF" BorderColor="#000099" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Larger"></asp:Label>
                      </td>
                   <td>
                      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                  </td>
                   <td>
                       <asp:Label ID="Label3" runat="server" Text="Where you want to go?" BackColor="#0066FF" BorderColor="#000099" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Larger"></asp:Label>
                       </td>
                    <td>
                       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    
                   </td>

                   <td>
                      <asp:Button ID="ButtonGo" runat="server" Text="GO!" OnClick="ButtonGo_Click" OnClientClick="check()" />
                      </td>
                
                    <td>
                        </td>
               </tr>
            </table>


       


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
        
    </form>
</body>
</html>
