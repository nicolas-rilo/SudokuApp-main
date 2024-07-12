using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.TournamentDao;
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
            List<TournamentDto> tournaments = SessionManager.getActiveTournaments(Context);


            Repeater1.DataSource = tournaments;
            Repeater1.DataBind();

        }

        
        protected void viewRanking(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect(Response.ApplyAppPathModifier($"~/Pages/Tournament/Ranking.aspx?id={btn.CommandArgument}"));
        }

        protected void selectSudoku(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TournamentDto tournamentDto = SessionManager.getTournament(Context,long.Parse(btn.CommandArgument));
            Response.Redirect(Response.ApplyAppPathModifier($"~/Pages/Sudoku/ResolveSudoku.aspx?id={tournamentDto.sudokuId}&tournamentId={btn.CommandArgument}&tournament=true"));
        }

        protected void createTournament(object sender, EventArgs e) {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Tournament/CreateTournament.aspx"));
        }

    }
}