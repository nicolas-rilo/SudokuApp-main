<%@ Page Language="C#" MasterPageFile="~/SudokuApp.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Home" meta:resourcekey="Page"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <br />
    <br />
    <asp:Localize ID="lclContent" runat="server" meta:resourcekey="lclContent" />

    <div id="form">
        <form runat="server">
            <div class="button">
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Table id="Table1" 
                GridLines="Both" 
                HorizontalAlign="Center" 
                Font-Names="Verdana" 
                Font-Size="8pt" 
                CellPadding="15" 
                CellSpacing="0" 
                Runat="server"/>

            <div class="button">


            </div>
        </form>
    </div>
</asp:Content>
