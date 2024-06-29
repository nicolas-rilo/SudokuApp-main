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
            
            <div class="button">
                <asp:Button ID="btnSwitch" runat="server" meta:resourcekey="btnSwitch" OnClick="switchTable" />
            </div>
            <div class="button">
                <asp:Button ID="btnSwitch2" runat="server" meta:resourcekey="btnSwitch2" OnClick="switchTable" />
            </div>

            <asp:Table id="Table1" Runat="server"/>
            <asp:Table id="Table2" Runat="server"/>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSudokuName" runat="server" meta:resourcekey="lclSudokuName" /></span><span class="entry">
                        <asp:TextBox ID="txtSudokuName" runat="server" Width="100px" Columns="16"
                            meta:resourcekey="txtSudokuNameResource"></asp:TextBox>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSudokuRules" runat="server" meta:resourcekey="lclSudokuRules" /></span><span class="entry">
                        <asp:TextBox ID="txtSudokuRules" runat="server" Width="100px" Columns="16"
                            meta:resourcekey="txtSudokuRulesResource"></asp:TextBox>
            </div>

             <div class="field">
                <span class="label">
                    <asp:Localize ID="lclDificulty" runat="server" meta:resourcekey="lclDificulty" /></span><span class="entry">

                    <asp:DropDownList ID="DdDificulty" runat="server">

                        <asp:ListItem Text="Easy" Value="Easy"></asp:ListItem>

                        <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>

                        <asp:ListItem Text="Hard" Value="Hard"></asp:ListItem>


                    </asp:DropDownList>
            </div>

            <div class="button">
                <asp:Button ID="btnUpload" runat="server" meta:resourcekey="btnUpload" OnClick="uploadSudoku" />
            </div>
        </form>
    </div>
</asp:Content>
