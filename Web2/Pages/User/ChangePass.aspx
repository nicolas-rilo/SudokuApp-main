<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master"  CodeBehind="ChangePass.aspx.cs" 
    Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.User.ChangePass" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="ProfileForm" method="POST" runat="server">
        <div class="field">
                <span class="label">
                <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span class="entry">
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server"
                    Width="100px" Columns="16" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator></span>
        </div>
        <asp:Label ID="lclPassError" runat="server"  meta:resourcekey="lclPassError" />

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclRetypePassword" runat="server" meta:resourcekey="lclRetypePassword" /></span><span
                    class="entry">
                    <asp:TextBox TextMode="Password" ID="txtRetypePassword" runat="server" Width="100px"
                        Columns="16" meta:resourcekey="txtRetypePasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvRetypePasswordResource1"></asp:RequiredFieldValidator>
        </div>

        <div class="button">
            <asp:Button ID="btnSave" runat="server" OnClick="changePass" meta:resourcekey="btnSave" />
        </div>
    </form>
</asp:Content>
