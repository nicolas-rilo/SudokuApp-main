<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master"  CodeBehind="ChangePass.aspx.cs" 
    Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.User.ChangePass" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id ="cenetering">
    <div id="user-stuff">
    <div id="form">
    <form id="ProfileForm" method="POST" runat="server">
        <div class="field">
                <span class="label">
                <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span class="entry">
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server"
                    meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator></span>
        </div>
        <asp:Label ID="lclPassError" runat="server"  meta:resourcekey="lclPassError" />

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclRetypePassword" runat="server" meta:resourcekey="lclRetypePassword" /></span><span
                    class="entry">
                    <asp:TextBox TextMode="Password" ID="txtRetypePassword" runat="server" meta:resourcekey="txtRetypePasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                        Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvRetypePasswordResource1"></asp:RequiredFieldValidator>
        </div>

        <div class="button">
            <asp:Button ID="btnSave" runat="server" OnClick="changePass" meta:resourcekey="btnSave" />
        </div>
    </form>
    </div>
    </div>
    </div>
</asp:Content>
