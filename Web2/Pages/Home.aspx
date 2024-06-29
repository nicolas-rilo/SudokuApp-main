<%@ Page Language="C#" MasterPageFile="~/SudokuApp.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Home" meta:resourcekey="Page"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <br />
    <br />
    <asp:Localize ID="lclContent" runat="server" meta:resourcekey="lclContent" />

    <div id="form">
        <form runat="server">
            <div class="button">
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="button">
                <asp:Button ID="btnNormal" runat="server" meta:resourcekey="btnNormal" OnClick="resultNormal" />
            </div>
            <div class="button">
                <asp:Button ID="btnCustom" runat="server" meta:resourcekey="btnCustom" OnClick="resultCustom" />
            </div>
            <asp:Repeater id="Repeater1" runat="server">
              <HeaderTemplate>
                 <table border="1">
                    <tr>
                       <td><b>Name</b></td>
                       <td><b>Rules</b></td>
                       <td><b>Dificulty</b></td>
                    </tr>
              </HeaderTemplate>


              <ItemTemplate>
                 <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>

                 </tr>
              </ItemTemplate>
             
              <FooterTemplate>
                 </table>
              </FooterTemplate>
             
           </asp:Repeater>

        </form>
    </div>
</asp:Content>
