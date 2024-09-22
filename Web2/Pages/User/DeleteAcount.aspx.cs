using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.User
{
    public partial class DeleteAcount : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.Logout(Context);
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}