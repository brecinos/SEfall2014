<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="InitialFrontal.aspx.cs" Inherits="SE2014Project.InitialFrontal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    
    </div>

        <table>
            <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Where are you?" CSSClass="two" BorderColor="#000099" Font-Bold="True"  Font-Names="Arial" Font-Size="Larger"></asp:Label>
                      </td>
                   <td>
                      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                  </td>
                   <td>
                       <asp:Label ID="Label3" runat="server" Text="Where do you want to go?"  BorderColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="Larger"></asp:Label>
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
            <tr>
                <td>
                    <asp:Button ID="ButtonStepList" runat="server" Text="List all steps" Font-Bold="True" Visible="false" OnClick="ButtonStepList_Click" />
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
        
</asp:Content>
