<%@ Page Language="C#" MasterPageFile="~/SudokuApp.Master" 
    EnableEventValidation="false" CodeBehind="Home.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Home" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <div id ="cenetering2">
    <div id="home">
        <form runat="server">


            <div class="field">
                <span class="label">    
                    <asp:Localize ID="lclFindSudoku" runat="server" meta:resourcekey="lclFindSudoku" />
                </span>
                <span class="entry">
                    <asp:TextBox ID="txtSudoku" runat="server" meta:resourcekey="txtSudoku"></asp:TextBox>
                </span>
            </div>

            <div id="parameters">

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSudokuType" runat="server" meta:resourcekey="lclSudokuType" /></span><span class="entry">

                    <asp:DropDownList ID="DdType" runat="server">

                        <asp:ListItem Text="----" Value="-"></asp:ListItem>

                        <asp:ListItem Text="Classic" Value="Normal"></asp:ListItem>

                        <asp:ListItem Text="Custom" Value="Custom"></asp:ListItem>

                        <asp:ListItem Text="Arrow" Value="Arrow"></asp:ListItem>

                        <asp:ListItem Text="Thermal" Value="Thermal"></asp:ListItem>

                        <asp:ListItem Text="Killer" Value="Killer"></asp:ListItem>


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
            </div>
            <div class="button">
                <asp:Button ID="btnSearch" runat="server" meta:resourcekey="btnSearch" OnClick="searchSudoku" />
            </div>


            <asp:Repeater id="Repeater2" runat="server">
              <HeaderTemplate>
                 <table border="1">
                    <tr>
                        <td><b><asp:Label ID="lblName" runat="server" meta:resourcekey="lblName"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblRules" runat="server" meta:resourcekey="lblRules"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblDificulty" runat="server" meta:resourcekey="lblDificulty"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblReview" runat="server" meta:resourcekey="lblReview"></asp:Label></b></td>
                        <td><b></b></td>

                    </tr>
              </HeaderTemplate>


              <ItemTemplate>
                 <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>
                    <td> <%# long.Parse(DataBinder.Eval(Container.DataItem, "review").ToString()) == 0?"":DataBinder.Eval(Container.DataItem, "review")+"/5"  %> </td>
                    <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "sudokuId")%>' ID="btnSelect" meta:resourcekey="btnSelect" OnClick="selectSudoku" /> </td>


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
            <div id="types">
                <div class="button">
                    <asp:Button ID="btnNormal" runat="server" meta:resourcekey="btnNormal" OnClick="resultNormal" />
                </div>
                <div class="button">
                    <asp:Button ID="btnThermal" runat="server" meta:resourcekey="btnThermal" OnClick="resultThermal" />
                </div>
                <div class="button">
                    <asp:Button ID="btnArrow" runat="server" meta:resourcekey="btnArrow" OnClick="resultArrow" />
                </div>
                <div class="button">
                    <asp:Button ID="btnKiller" runat="server" meta:resourcekey="btnKiller" OnClick="resultKiller" />
                </div>
                <div class="button">
                    <asp:Button ID="btnCustom" runat="server" meta:resourcekey="btnCustom" OnClick="resultCustom" />
                </div>

            </div>

            <div id="table">
            <asp:Repeater id="Repeater1" runat="server">
              <HeaderTemplate>
                 <table border="1">
                    <tr>
                        <td><b><asp:Label ID="lblName" runat="server" meta:resourcekey="lblName"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblRules" runat="server" meta:resourcekey="lblRules"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblDificulty" runat="server" meta:resourcekey="lblDificulty"></asp:Label></b></td>
                        <td><b><asp:Label ID="lblReview" runat="server" meta:resourcekey="lblReview"></asp:Label></b></td>
                       <td><b></b></td>

                    </tr>
              </HeaderTemplate>


              <ItemTemplate>
                 <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "name") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "rules") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "dificulty") %> </td>
                    <td> <%# long.Parse(DataBinder.Eval(Container.DataItem, "review").ToString()) == 0?"":DataBinder.Eval(Container.DataItem, "review")+"/5"  %> </td>
                    <td> <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "sudokuId")%>' ID="btnSelect" meta:resourcekey="btnSelect" OnClick="selectSudoku" /> </td>

                 </tr>
              </ItemTemplate>
             
              <FooterTemplate>
                 </table id="tabla1">
              </FooterTemplate>
             
           </asp:Repeater>
           </div>

        </form>
    </div>
    </div>
</asp:Content>
