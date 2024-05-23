<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="UploadSudoku.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.UploadSudoku" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div runat="server" id="prueba" class="prueba">
        <form runat="server">

            <span class="entry">
                <asp:Localize ID="lblExplanation" runat="server" meta:resourcekey="lblExplanation" />
            </span>
            <div class="checkbox">
                <asp:CheckBox ID="checkNormal" runat="server" TextAlign="Left" meta:resourcekey="checkNormal" />
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkKiller" runat="server" TextAlign="Left" meta:resourcekey="checkKiller" />
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkThermal" runat="server" TextAlign="Left" meta:resourcekey="checkThermal" />
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkArrow" runat="server" TextAlign="Left" meta:resourcekey="checkArrow" />
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkCustom" runat="server" TextAlign="Left" meta:resourcekey="checkCustom" />
            </div>

            <asp:Table id="Table1" Runat="server"/>

            <div class="button">
                <asp:Button ID="btnUpload" runat="server" meta:resourcekey="btnUpload" OnClick="uploadSudoku" />
            </div>
        </form>
    </div>
</asp:Content>
