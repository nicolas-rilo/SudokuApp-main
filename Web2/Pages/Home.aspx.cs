using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages
{
    public partial class Home : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context,null,null,true,false,false,false,false,0,8);
 
 
             Repeater1.DataSource = sudokuDtos;
             Repeater1.DataBind();

        }

        protected void selectSudoku(object sender, EventArgs e) {
            Button btn = (Button)sender;
            Response.Redirect(Response.ApplyAppPathModifier($"~/Pages/Sudoku/ResolveSudoku.aspx?id={btn.CommandArgument}"));


        }
        protected void searchSudoku(object sender, EventArgs e)
        {
            String dificulty = DbDificulty.SelectedValue;
            if (DbDificulty.SelectedValue == "null") {
                dificulty = null;
            }
            List<SudokuDto> sudokuDtos;


            sudokuDtos = SessionManager.findByFilter(Context, txtSudoku.Text, dificulty, DdType.SelectedValue == "Normal", DdType.SelectedValue == "Killer"
                , DdType.SelectedValue == "Thermal", DdType.SelectedValue == "Arrow", DdType.SelectedValue == "Custom",0,8);


            Repeater2.DataSource = sudokuDtos;
            Repeater2.DataBind();

        }

        protected void resultNormal(object sender, EventArgs e) {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null,true ,false, false, false, false, 0, 8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }



        protected void resultThermal(object sender, EventArgs e)
        {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null, false, false, true, false, false,0,8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }
        protected void resultArrow(object sender, EventArgs e)
        {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null, false, false, false, true, false,0,8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }
        protected void resultKiller(object sender, EventArgs e)
        {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null, false, true, false, false, false,0,8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }



        protected void resultCustom(object sender, EventArgs e)
        {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null,false, false, false, false, true, 0, 8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }


    }

}