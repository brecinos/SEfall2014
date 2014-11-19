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
                <td >
                    <asp:Button ID="ButtonPrevious" runat="server" Text="Previous" BackColor="Black" ForeColor="#FFFFCC" Height="442px"  Width="83px" OnClick="ButtonPrevious_Click"/>
                    
                </td>
                <td >
                    
                    <asp:Image ID="Image1" runat="server" Height="487px"  Width="749px"   />
                </td>
                   <td >
                    <asp:Button ID="ButtonNext" runat="server" Text="Next" BackColor="Black" ForeColor="#FFFFCC" Height="438px" Width="69px" OnClick="ButtonNext_Click" />
                </td>
            </tr>
            <tr>
                <td> </td>
                <td>
                        <asp:ImageMap ID="ImageMap1" runat="server" Height="48px"  Width="49px" ></asp:ImageMap>
                </td>
                <td> </td>
            </tr>
            </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>