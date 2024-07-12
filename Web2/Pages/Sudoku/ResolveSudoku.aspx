﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    EnableEventValidation="false"  CodeBehind="ResolveSudoku.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.ResolveSudoku" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <div runat="server" id="prueba" class="prueba">
        <form runat="server">
            <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Font-Size="XX-Large"></asp:Label>
                <asp:Timer ID="tm1" Interval="1000" runat="server" ontick="tm1_Tick" />
              </ContentTemplate>
              <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tm1" EventName="Tick" />
              </Triggers>
            </asp:UpdatePanel>

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

