<%@ Page Language="C#" MasterPageFile="~/SudokuApp.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Home" meta:resourcekey="Page"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <br />
    <asp:Localize ID="lclContent" runat="server" meta:resourcekey="lclContent" />

    <div id="form">
        <form runat="server">
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
                    </tr>
              </HeaderTemplate>


              <ItemTemplate>
                 <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>

                 </tr>
              </ItemTemplate>
             
              <FooterTemplate>
                 </table>
              </FooterTemplate>
             
           </asp:Repeater>


            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="button">
                <asp:Button ID="btnNormal" runat="server" meta:resourcekey="btnNormal" OnClick="resultNormal" />
            </div>
            <div class="button">
                <asp:Button ID="btnCustom" runat="server" meta:resourcekey="btnCustom" OnClick="resultCustom" />
            </div>
            <asp:Repeater id="Repeater1" runat="server">
              <HeaderTemplate>
                 <table border="1">
                    <tr>
                       <td><b>Name</b></td>
                       <td><b>Rules</b></td>
                       <td><b>Dificulty</b></td>
                    </tr>
              </HeaderTemplate>


              <ItemTemplate>
                 <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>

                 </tr>
              </ItemTemplate>
             
              <FooterTemplate>
                 </table>
              </FooterTemplate>
             
           </asp:Repeater>

        </form>
    </div>
</asp:Content>
