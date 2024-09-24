<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" CodeBehind="Profile.aspx.cs" 
    Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.User.Profile" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id ="cenetering2">
    <div id ="profile">

    <form id="ProfileForm" method="POST" runat="server">

    <div id="FirstLine">
        <div id="data">
            <div id="Username">
                <asp:Localize ID="lclUsername" runat="server" meta:resourcekey="lclUsername" />
                <span id="textUsername">
                    <asp:Label ID="lblUsername" runat="server" meta:resourcekey="lblUsername">       
                    </asp:Label>
                </span>
            </div>
            <div id="FirstName">
                <asp:Localize ID="lclFirstName" runat="server" meta:resourcekey="lclFirstName" />
                <span id="textFirstName">
                    <asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblUsername">       
                    </asp:Label>
                </span>
            </div>
            <div id="LastName">
                <asp:Localize ID="lclLastName" runat="server" meta:resourcekey="lclLastName" />
                <span id="textLastName">
                    <asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblUsername">       
                    </asp:Label>
                </span>
            </div>
        </div>
        <div id="links">
            <asp:HyperLink ID="lnkModifiProfile" runat="server" NavigateUrl="~/Pages/User/ModifyProfile.aspx"
                                     meta:resourcekey="lnkModifiProfile"></asp:HyperLink>

            <asp:HyperLink ID="lnkDeleteAcount" runat="server" NavigateUrl="~/Pages/User/DeleteAcount.aspx"
                                     meta:resourcekey="lnkDeleteAcount"></asp:HyperLink>
        </div>

    </div>
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
    </div>
    </div>
</asp:Content>

