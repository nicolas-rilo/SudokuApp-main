<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SudokuApp.Master" 
    CodeBehind="UploadSudoku.aspx.cs" Inherits="Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku.UploadSudoku" meta:resourcekey="Page" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <script type="text/javascript" language="javascript">  
        $(document).ready(function (e) {
            try {
                $("#ddlprofile").msDropDown();
            } catch (e) {
                alert(e.message);
            }
        });
</script>
    <div runat="server" id="prueba" class="prueba">
    <div id="sudokuCreator">
        <form runat="server">
            <div id="explanation">
                <span class="entry">
                    <asp:Localize ID="lblExplanation" runat="server" meta:resourcekey="lblExplanation" />
                </span>
            </div>

            <div id="categories">
                <div class="checkbox">
                    <asp:CheckBox ID="checkNormal" runat="server" TextAlign="Right" meta:resourcekey="checkNormal" />
                </div>
                <div class="checkbox">
                    <asp:CheckBox ID="checkKiller" runat="server" TextAlign="Right" meta:resourcekey="checkKiller" />
                </div>
                <div class="checkbox">
                    <asp:CheckBox ID="checkThermal" runat="server" TextAlign="Right" meta:resourcekey="checkThermal" />
                </div>
                <div class="checkbox">
                    <asp:CheckBox ID="checkArrow" runat="server" TextAlign="Right" meta:resourcekey="checkArrow" />
                </div>
                <div class="checkbox">
                    <asp:CheckBox ID="checkCustom" runat="server" TextAlign="Right" meta:resourcekey="checkCustom" />
                </div>
            </div>


            <div id="total">
            <div id="sudoku-switch">
                <div class="button">
                    <asp:Button ID="btnSwitch" runat="server" meta:resourcekey="btnSwitch" OnClick="switchTable" />
                </div>
                <div class="button">
                    <asp:Button ID="btnSwitch2" runat="server" meta:resourcekey="btnSwitch2" OnClick="switchTable" />
                </div>

                <span style="color:red">
                    <asp:Localize ID="lclSolution" runat="server" meta:resourcekey="lclSolution" />
                </span>

                <asp:Table id="Table1" CssClass="sudoku" Runat="server"/>
                <asp:Table id="Table2" CssClass="sudoku" Runat="server"/>
                <div id="hh">
                    <div class="button">
                        <asp:Button ID="btnUpload" runat="server" meta:resourcekey="btnUpload" OnClick="uploadSudoku" />
                    </div>
                </div>
            </div>


            <div id="sudoku-creation">
                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclSudokuName" runat="server" meta:resourcekey="lclSudokuName" /></span><span class="entry">
                            <asp:TextBox ID="txtSudokuName" runat="server"
                                meta:resourcekey="txtSudokuNameResource"></asp:TextBox>
                            </span>
                </div>
                <div class="field">
                    <span class="label">
                        <asp:Localize ID="lclSudokuRules" runat="server" meta:resourcekey="lclSudokuRules" /></span><span class="entry">
                            <asp:TextBox ID="txtSudokuRules" runat="server"
                                meta:resourcekey="txtSudokuRulesResource"></asp:TextBox>
                            </span>
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


                <div id="paths">
                    <asp:Table id="ThermoPath" CssClass="sudoku" Runat="server"/>

                    <div class="button">
                        <asp:Button ID="btnAddPath" runat="server" meta:resourcekey="btnAddPath" OnClick="AddPath" />
                    </div>
                    <div class="button">
                        <asp:Button ID="btnCreate" runat="server" meta:resourcekey="btnCreate" OnClick="CreateThermo" />
                    </div>


                    <asp:Table id="ArrowPath" CssClass="sudoku" Runat="server"/>

                    <div class="button">
                        <asp:Button ID="btnAddArrow" runat="server" meta:resourcekey="btnAddArrow" OnClick="AddArrow" />
                    </div>
                    <div class="button">
                        <asp:Button ID="btnCreate2" runat="server" meta:resourcekey="btnCreate" OnClick="CreateArrow" />
                    </div>

                    <asp:Table id="KillerPath" CssClass="sudoku" Runat="server"/>
                    <div class="button">
                        <asp:Button ID="btnAddKiller" runat="server" meta:resourcekey="btnAddKiller" OnClick="AddKiller" />
                    </div>
                    <div class="button">
                        <asp:Button ID="btnCreate3" runat="server" meta:resourcekey="btnCreate" OnClick="CreateKiller" />
                    </div>
                </div>

            </div>
            </div>

            
            

            


        </form>
    </div>
    </div>
</asp:Content>
