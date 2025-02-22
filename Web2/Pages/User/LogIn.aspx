﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" CodeBehind="LogIn.aspx.cs"
    Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.User.LogIn" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id ="cenetering">
        <div id="user-stuff">
            <form id="AuthenticationForm" method="POST" runat="server">
                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclLogin" runat="server" meta:resourcekey="lclLogin" /></span><span
                        class="entry">
                            <asp:TextBox ID="txtLogin" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server"
                                ControlToValidate="txtLogin" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                            <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Style="position: relative"
                                Visible="False" meta:resourcekey="lblLoginError">                        
                            </asp:Label>
                    </span>
                </div>
                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span
                            class="entry">
                            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                ControlToValidate="txtPassword" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                            <asp:Label ID="lblPasswordError" runat="server" ForeColor="Red" Style="position: relative"
                                Visible="False" meta:resourcekey="lblPasswordError">       
                            </asp:Label>
                    </span>
                </div>
                <div class="checkbox">
                    <asp:CheckBox ID="checkRememberPassword" runat="server" TextAlign="Left" meta:resourcekey="checkRememberPassword" />
                </div>
                <div class="button">
                    <asp:Button id="btnLogin" runat="server" OnClick="BtnLoginClick" meta:resourcekey="btnLogin" />
                </div>
                <br />
                <div class="button">
                    <asp:Button ID="btnRegister" runat="server" OnClick="switchRegister" meta:resourcekey="lnkRegister" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
