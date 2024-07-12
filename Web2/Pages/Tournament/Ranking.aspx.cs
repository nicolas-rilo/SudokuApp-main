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
    public partial class Ranking : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.IsUserAuthenticated(Context))
            {
                Repeater2.Visible = true;
                List<ParticipationDto> userPosition = new List<ParticipationDto>();
                try
                {
                    ParticipationDto participationDto = SessionManager.getUserPosition(Context, long.Parse(Request.QueryString["id"]));
                    lblExp.Visible = true;
                    userPosition.Add(participationDto);
                    Repeater2.DataSource = userPosition;
                    Repeater2.DataBind();

                }
                catch (ModelUtil.Exceptions.InstanceNotFoundException) { }
            }
            List<ParticipationDto> participationDtos = SessionManager.getRanking(Context, long.Parse(Request.QueryString["id"]),0,8);
            Repeater1.DataSource = participationDtos;
            Repeater1.DataBind();
        }
    }
}