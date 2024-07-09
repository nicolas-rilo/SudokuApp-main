<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="ResolveSudoku.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.ResolveSudoku" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div runat="server" id="prueba" class="prueba">
        <form runat="server">
            <asp:Table id="Table1" Runat="server"/>
            <asp:Table id="Table2" Runat="server"/>

            <div class="button">
                <asp:Button ID="btnSolve" runat="server" meta:resourcekey="btnSolve" OnClick="validateSolution"  />
            </div>
            <span class="entry">
                <asp:Localize ID="lblExplanation" runat="server" meta:resourcekey="lblExplanation" />
            </span>
            <span class="entry">
                <asp:Localize ID="lblRules" runat="server" meta:resourcekey="lblRules" />
            </span>
            <span class="entry">
                <asp:Localize ID="lblSudokuExp" runat="server" meta:resourcekey="lblSudokuExp" />
            </span>
            <div class="button">
                <asp:Button ID="btnAccept" runat="server" meta:resourcekey="btnAccept" OnClick="endSudoku"  />
            </div>

        </form>
    </div>
</asp:Content>

