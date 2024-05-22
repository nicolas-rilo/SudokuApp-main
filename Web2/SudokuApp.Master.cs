using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web
{
    public partial class SudokuApp : System.Web.UI.MasterPage
    {
        public static readonly String USER_SESSION_ATTRIBUTE = "userSession";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsUserAuthenticated(Context))
            {
                if (lnkProfile != null)
                    lnkProfile.Visible = false;
                if (lnkLogout != null)
                    lnkLogout.Visible = false;
            }
            else
            {
                if (lnkRegister != null)
                    lnkRegister.Visible = false;
                if (lnkAuthentication != null)
                    lnkAuthentication.Visible = false;
            }
        }
    }
}