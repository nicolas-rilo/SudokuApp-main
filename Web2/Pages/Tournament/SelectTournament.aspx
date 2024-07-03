<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="SelectTournament.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament.SelectTournament" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <form runat="server">
        <div class="button">
            <asp:Button ID="btnCrTour" runat="server" meta:resourcekey="btnCrTour" OnClick="createTournament"  />
        </div>
    </form>
</asp:Content>

