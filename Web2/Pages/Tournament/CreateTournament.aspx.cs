using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament
{
    public partial class CreateTournament : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!SessionManager.IsUserAuthenticated(Context))
            {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/LogIn.aspx"));
            }
            btnEdit.Visible = false;
            lblSudokuIdSafe.Visible = false;
        }


        
        protected void editSelection(object sender, EventArgs e) {
            lclFindSudoku.Visible = true;
            lclSudokuType.Visible = true;
            lclDificulty.Visible = true;
            DbDificulty.Visible = true;
            DdType.Visible = true;
            txtSudoku.Visible = true;
            btnSearch.Visible = true;
            Repeater2.Visible = false;
            btnEdit.Visible = false;


        }

        protected void selectSudoku(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            List<SudokuDto> sudokuDtos = SessionManager.findSudoku(Context,long.Parse(btn.CommandArgument.ToString()));

            lblSudokuIdSafe.Text = btn.CommandArgument.ToString();

            Repeater2.DataSource = sudokuDtos;
            Repeater2.DataBind();
            lclFindSudoku.Visible = false;
            lclSudokuType.Visible = false;
            lclDificulty.Visible = false;
            DbDificulty.Visible = false;
            DdType.Visible = false;
            txtSudoku.Visible = false;
            btnSearch.Visible = false;
            btnEdit.Visible = true;


        }
        protected void searchSudoku(object sender, EventArgs e) {
            Repeater2.Visible = true;

            String dificulty = DbDificulty.SelectedValue;
            if (DbDificulty.SelectedValue == "null")
            {
                dificulty = null;
            }
            List<SudokuDto> sudokuDtos;
            if (DdType.SelectedValue == "Normal")
            {
                sudokuDtos = SessionManager.findByFilter(Context, txtSudoku.Text, dificulty, true, false, false, false, false, 0, 8);
            }
            else if (DdType.SelectedValue == "Custom")
            {
                sudokuDtos = SessionManager.findByFilter(Context, txtSudoku.Text, dificulty, false, false, false, false, true, 0, 8);

            }
            else
            {
                sudokuDtos = SessionManager.findByFilter(Context, txtSudoku.Text, dificulty, false, false, false, false, false, 0, 8);
            }

            Repeater2.DataSource = sudokuDtos;
            Repeater2.DataBind();

        }

        protected void uploadTournament(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', '/', '.', ':', '\t' };


            //assigns year, month, day, hour, min, seconds
            //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
            //DD/MM/YYYY HH:MM:SS

            string[] words = txtStartDateTime.Text.Split(delimiterChars);
            if (words.Length < 5) {
                lblFormatError.Visible = true;
            }

            DateTime start = new DateTime(int.Parse(words[2]), int.Parse(words[1]), int.Parse(words[0]), 
                int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]));


            string[] words2 = txtEndDateTime.Text.Split(delimiterChars);

            if (words2.Length < 5)
            {
                lblFormatError2.Visible = true;
            }

            DateTime end = new DateTime(int.Parse(words2[2]), int.Parse(words2[1]), int.Parse(words2[0]),
                int.Parse(words2[3]), int.Parse(words2[4]), int.Parse(words2[5]));

            if (start.CompareTo(end)>=0) {
                lblNotAfter.Visible = true;
            }
            else if (lblSudokuIdSafe.Text== "Label Control") {
                lblSelectSdk.Visible = true;            
            }
            else { 
                SessionManager.createTournament(Context, long.Parse(lblSudokuIdSafe.Text),start,end);
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Tournament/SelectTournament.aspx"));
            }
        }
    }
}