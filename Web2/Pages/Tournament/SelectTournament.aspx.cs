using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Tournament
{
    public partial class SelectTournament : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsUserAuthenticated(Context))
            {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/LogIn.aspx"));
            }
            btnCrTour.Visible = SessionManager.isUserAdmin(Context);


        }
        protected void createTournament(object sender, EventArgs e) {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Tournament/CreateTournament.aspx"));
        }

    }
}