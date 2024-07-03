using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        }

        protected void uploadTournament(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', '/', '.', ':', '\t' };

            //assigns year, month, day, hour, min, seconds
            //DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
            //DD/MM/YYYY HH:MM:SS
            string[] words = txtStartDateTime.Text.Split(delimiterChars);
            DateTime start = new DateTime(int.Parse(words[2]), int.Parse(words[1]), int.Parse(words[0]), 
                int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]));

            string[] words2 = txtEndDateTime.Text.Split(delimiterChars);
            DateTime end = new DateTime(int.Parse(words2[2]), int.Parse(words2[1]), int.Parse(words2[0]),
                int.Parse(words2[3]), int.Parse(words2[4]), int.Parse(words2[5]));

            if (start > end) {
                //Mensaje de error
            }

            SessionManager.createTournament(Context,long.Parse(txtSudokuId.Text),start,end);
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Tournament/SelectTournament.aspx"));

        }
    }
}