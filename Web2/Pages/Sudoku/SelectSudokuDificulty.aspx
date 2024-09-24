<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="SelectSudokuDificulty.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.SelectSudokuDificulty" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div runat="server">
        <div id ="cenetering2">
        <div id="Selector">

        <form runat="server">

            <span class="entry">
                <asp:Localize ID="lblExplanation" runat="server" meta:resourcekey="lblExplanation" />
            </span>

            <div id="dificultis">
                <div id="easy">
                    <div class="button">
                        <asp:Button ID="btnEasy" runat="server"  CommandArgument="0" meta:resourcekey="btnEasy" OnClick="selectDif" />
                    </div>
                </div>
                <div id="medium">
                    <div class="button">
                        <asp:Button ID="btnMedium" runat="server" CommandArgument="1" meta:resourcekey="btnMedium" OnClick="selectDif" />
                    </div>
                </div>
                <div id="hard">
                    <div class="button">
                        <asp:Button ID="btnHard" runat="server" CommandArgument="2" meta:resourcekey="btnHard" OnClick="selectDif" />
                    </div>
                </div>
            </div>

        </form>
    </div>
    </div>
    </div>

</asp:Content>

