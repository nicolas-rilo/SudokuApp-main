<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="CreateTournament.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament.CreateTournament" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <form runat="server">

        <asp:Label id="lblSudokuIdSafe" Text="Label Control" runat="server"/>

        <div class="field">
            <span class="label">
                <asp:Localize ID="lclStartDateTime" runat="server" meta:resourcekey="lclStartDateTime" /></span><span class="entry">
                    <asp:TextBox ID="txtStartDateTime" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtStartDateTimeResource"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStartDate" runat="server"
                        ControlToValidate="txtStartDateTime" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                    <asp:Label ID="lblFormatError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblFormatError">       
                    </asp:Label>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclEndDateTime" runat="server" meta:resourcekey="lclEndDateTime" /></span><span class="entry">
                    <asp:TextBox ID="txtEndDateTime" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtEndDateTimeResource"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtEndDateTimeResource" runat="server"
                        ControlToValidate="txtEndDateTime" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                    <asp:Label ID="lblFormatError2" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblFormatError">       
                    </asp:Label>
        </div>
        <asp:Label ID="lblNotAfter" runat="server" ForeColor="Red" Style="position: relative"
                Visible="False" meta:resourcekey="lblNotAfter">       
        </asp:Label>


            <br />

            <br />

            <br />



        <div class="field">
            <span class="label">    
                <asp:Localize ID="lclFindSudoku" runat="server" meta:resourcekey="lclFindSudoku" /></span>
            <span class="entry">
                    <asp:TextBox ID="txtSudoku" runat="server" Width="100" meta:resourcekey="txtSudoku"></asp:TextBox>
            </span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclSudokuType" runat="server" meta:resourcekey="lclSudokuType" /></span><span class="entry">

                <asp:DropDownList ID="DdType" runat="server">

                    <asp:ListItem Text="----" Value="-"></asp:ListItem>

                    <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>

                    <asp:ListItem Text="Custom" Value="Custom"></asp:ListItem>

                    <asp:ListItem Text="Chess" Value="Chess"></asp:ListItem>


                </asp:DropDownList>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclDificulty" runat="server" meta:resourcekey="lclDificulty" /></span><span class="entry">

                <asp:DropDownList ID="DbDificulty" runat="server">

                    <asp:ListItem Text="----" Value="null"></asp:ListItem>

                    <asp:ListItem Text="Easy" Value="Easy"></asp:ListItem>

                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>

                    <asp:ListItem Text="Hard" Value="Hard"></asp:ListItem>


                </asp:DropDownList>
        </div>
        <div class="button">
            <asp:Button ID="btnSearch" runat="server" meta:resourcekey="btnSearch" OnClick="searchSudoku" />
        </div>

        <asp:Repeater id="Repeater2" runat="server">
            <HeaderTemplate>
                <table border="1">
                <tr>
                    <td><b>Name</b></td>
                    <td><b>Rules</b></td>
                    <td><b>Dificulty</b></td>
                    <td><b></b></td>
                </tr>
            </HeaderTemplate>


            <ItemTemplate >
                <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>
                <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "sudokuId")%>' ID="btnSelect" meta:resourcekey="btnSelect" OnClick="selectSudoku" /> </td>
                </tr>
            </ItemTemplate>
             
            <FooterTemplate>
                </table>
            </FooterTemplate>
             
        </asp:Repeater>
        <div class="button">
            <asp:Button ID="btnEdit" runat="server" meta:resourcekey="btnEdit" OnClick="editSelection" />
        </div>
            <br />

            <br />

            <br />

            <br />

        <asp:Label ID="lblSelectSdk" runat="server" ForeColor="Red" Style="position: relative"
                Visible="False" meta:resourcekey="lblSelectSdk">       
        </asp:Label>


        <div class="button">
            <asp:Button ID="btnUpload" runat="server" meta:resourcekey="btnUpload" OnClick="uploadTournament" />
        </div>
    </form>
</asp:Content>
