<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" CodeBehind="Profile.aspx.cs" 
    Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.User.Profile" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="ProfileForm" method="POST" runat="server">

    <asp:Label ID="lblUsername" runat="server" meta:resourcekey="lblUsername">       
    </asp:Label>
    <asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblUsername">       
    </asp:Label>
    <asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblUsername">       
    </asp:Label>
    <asp:HyperLink ID="lnkModifiProfile" runat="server" NavigateUrl="~/Pages/User/ModifyProfile.aspx"
                             meta:resourcekey="lnkModifiProfile"></asp:HyperLink>

    <asp:HyperLink ID="lnkDeleteAcount" runat="server" NavigateUrl="~/Pages/User/DeleteAcount.aspx"
                             meta:resourcekey="lnkDeleteAcount"></asp:HyperLink>

    
    <asp:Repeater id="Repeater2" runat="server">
        <HeaderTemplate>
            <table border="1">
            <tr>
                <td><b><asp:Label ID="lblName" runat="server" meta:resourcekey="lblName"></asp:Label></b></td>
                <td><b><asp:Label ID="lblRules" runat="server" meta:resourcekey="lblRules"></asp:Label></b></td>
                <td><b><asp:Label ID="lblDificulty" runat="server" meta:resourcekey="lblDificulty"></asp:Label></b></td>
                <td><b></b></td>

            </tr>
        </HeaderTemplate>


        <ItemTemplate>
            <tr>
            <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
            <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
            <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>
            <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "sudokuId")%>' ID="btnEdit" meta:resourcekey="btnEdit" OnClick="EditSudoku" /> </td>


            </tr>
        </ItemTemplate>
             
        <FooterTemplate>
            </table>
        </FooterTemplate>
             
    </asp:Repeater>




    </form>
</asp:Content>

