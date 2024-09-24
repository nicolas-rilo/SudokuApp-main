<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    EnableEventValidation="false" CodeBehind="Ranking.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament.Ranking" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id ="cenetering2">
    <div id="ranking">
    <form runat="server">
        <asp:Repeater id="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1">
                <tr>
                    <td><b>Rank</b></td>
                    <td><b>Time</b></td>
                    <td><b>UserName</b></td>
                </tr>
            </HeaderTemplate>


            <ItemTemplate >
                <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "rank") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "time") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "userName") %> </td>
                </tr>
            </ItemTemplate>
             
            <FooterTemplate>
                </table>
            </FooterTemplate>
             
        </asp:Repeater>
        

            <br />


        <span class="entry">
            <asp:Localize ID="lblExp" runat="server" Visible="false" meta:resourcekey="lblExp" />
        </span>


            <br />
        
        
        <asp:Repeater id="Repeater2" runat="server" Visible="false">
            <HeaderTemplate>
                <table border="1">
                <tr>
                    <td><b>Rank</b></td>
                    <td><b>Time</b></td>
                    <td><b>UserName</b></td>
                </tr>
            </HeaderTemplate>


            <ItemTemplate >
                <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "rank") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "time") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "userName") %> </td>
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
