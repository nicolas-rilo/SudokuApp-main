using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.User
{
    public partial class ChangePass : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lclPassError.BackColor = Color.Red;
            lclPassError.Visible = false;
        }
        protected void changePass(object sender, EventArgs e)
        {
            UserDetails userDetails = SessionManager.FindUserDetails(Context);
            try
            {
                SessionManager.ChangePassword(Context, txtPassword.Text, txtRetypePassword.Text);
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/ModifyProfile.aspx"));

            }
            catch (IncorrectPasswordException)
            {
                lclPassError.Visible = true;
            }

        }
    }
}