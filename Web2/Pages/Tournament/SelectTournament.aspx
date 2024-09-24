<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    EnableEventValidation="false" CodeBehind="SelectTournament.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament.SelectTournament" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id ="cenetering2">
    <div id ="home">
    <form runat="server">
        <div class="button">
            <asp:Button ID="btnCrTour" runat="server" meta:resourcekey="btnCrTour" OnClick="createTournament"  />
        </div>

        <asp:Repeater id="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1">
                <tr>
                    <td><b>Dificulty</b></td>
                    <td><b>Time</b></td>
                    <td><b>Participants</b></td>
                    <td><b>Participate</b></td>
                    <td><b>Ranking</b></td>

                </tr>
            </HeaderTemplate>


            <ItemTemplate>
                <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "days") %>d   <%# DataBinder.Eval(Container.DataItem, "hours") %>:<%# DataBinder.Eval(Container.DataItem, "minutes") %>:<%# DataBinder.Eval(Container.DataItem, "seconds") %></td>
                <td> <%# DataBinder.Eval(Container.DataItem, "participants") %> </td>
                <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "tournamentId")%>' ID="btnSelect" meta:resourcekey="btnSelect" OnClick="selectSudoku" /> </td>
                <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "tournamentId")%>' ID="btnRanking" meta:resourcekey="btnRanking" OnClick="viewRanking" /> </td>

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

