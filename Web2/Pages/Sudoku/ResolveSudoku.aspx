<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    EnableEventValidation="false"  CodeBehind="ResolveSudoku.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.ResolveSudoku" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="solve">
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
            <span class="label">
                <asp:Localize ID="lblRules" runat="server" meta:resourcekey="lblRules" />
            </span>
                        <span class="label1">
                <asp:Localize ID="lblSudokuExp" runat="server" meta:resourcekey="lblSudokuExp" />
            </span>

            <asp:Table id="Table1" CssClass="sudoku" Runat="server"/>
            <asp:Table id="Table2" CssClass="sudoku" Runat="server"/>



            <div class="button">
                <asp:Button ID="btnSolve" runat="server" meta:resourcekey="btnSolve" OnClick="validateSolution"  />
            </div>
            <span class="label2">
                <asp:Localize ID="lblExplanation" runat="server" meta:resourcekey="lblExplanation" />
            </span>


            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclReview" runat="server" meta:resourcekey="lclReview" /></span><span class="entry">

                    <asp:DropDownList ID="DbdReview" runat="server">

                        <asp:ListItem Text="0" Value="0"></asp:ListItem>

                        <asp:ListItem Text="1" Value="1"></asp:ListItem>

                        <asp:ListItem Text="2" Value="2"></asp:ListItem>

                        <asp:ListItem Text="3" Value="3"></asp:ListItem>

                        <asp:ListItem Text="4" Value="4"></asp:ListItem>

                        <asp:ListItem Text="5" Value="5"></asp:ListItem>

                    </asp:DropDownList>
            </div>
            <div class="button">
                <asp:Button ID="btnAccept" runat="server" meta:resourcekey="btnAccept" OnClick="endSudoku"  />
            </div>


        </form>
    </div>
    </div>
</asp:Content>

