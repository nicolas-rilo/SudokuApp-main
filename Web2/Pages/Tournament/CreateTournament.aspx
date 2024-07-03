<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="CreateTournament.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament.CreateTournament" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <form runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclStartDateTime" runat="server" meta:resourcekey="lclStartDateTime" /></span><span class="entry">
                    <asp:TextBox ID="txtStartDateTime" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtStartDateTimeResource"></asp:TextBox>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclEndDateTime" runat="server" meta:resourcekey="lclEndDateTime" /></span><span class="entry">
                    <asp:TextBox ID="txtEndDateTime" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtEndDateTimeResource"></asp:TextBox>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclSudokuId" runat="server" meta:resourcekey="lclSudokuId" /></span><span class="entry">
                    <asp:TextBox ID="txtSudokuId" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtSudokuIdTimeResource"></asp:TextBox>
        </div>
        <div class="button">
            <asp:Button ID="btnUpload" runat="server" meta:resourcekey="btnUpload" OnClick="uploadTournament" />
        </div>
    </form>
</asp:Content>
