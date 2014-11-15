<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="3dViewer.aspx.cs" Inherits="SE2014Project._3dViewer" %>

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
                     <asp:DropDownList ID="DropDownBuilding" runat ="server">

                     </asp:DropDownList>
                 </td>
                 <td >
                     <asp:DropDownList ID="DropDownRoom" runat="server" >
                         
                     </asp:DropDownList>
                 </td>
                 </tr>


            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Previous" BackColor="Black" ForeColor="#FFFFCC" Height="160px"  Width="70px"/>
                    
                </td>
                <td>
                    
                    <asp:Image ID="Image1" runat="server" Height="57px"  Width="49px"   />
                </td>
                   <td>
                    <asp:Button ID="Button1" runat="server" Text="Next" BackColor="Black" ForeColor="#FFFFCC" Height="160px" Width="69px" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td> </td>
                <td>
                        <asp:ImageMap ID="ImageMap1" runat="server" Height="487px"  Width="749px" ></asp:ImageMap>
                </td>
                <td> </td>
            </tr>
            </table>

</asp:Content>