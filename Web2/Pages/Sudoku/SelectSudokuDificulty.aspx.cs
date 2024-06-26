using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku
{
    public partial class SelectSudokuDificulty : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void selectDif(object sender, EventArgs e) {
            String dificulty = ((Button)sender).CommandArgument.ToString();
            Response.Redirect(Response.ApplyAppPathModifier($"~/Pages/Sudoku/ResolveSudoku.aspx?dificulty={dificulty}"));


        }
    
    }
}