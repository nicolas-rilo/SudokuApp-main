using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model.Exceptions;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.User
{
    public partial class LogIn : SpecificCulturePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblPasswordError.Visible = false;
            lblLoginError.Visible = false;
        }
        protected void BtnLoginClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SessionManager.Login(Context, txtLogin.Text,
                        txtPassword.Text, checkRememberPassword.Checked);

                    FormsAuthentication.
                        RedirectFromLoginPage(txtLogin.Text,
                            checkRememberPassword.Checked);

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));

                }
                catch (ModelUtil.Exceptions.InstanceNotFoundException)
                {
                    lblLoginError.Visible = true;
                }
                catch (IncorrectPasswordException)
                {
                    lblPasswordError.Visible = true;
                }
            }
        }



        protected void switchRegister(object sender, EventArgs e) {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/Register.aspx"));
        }

    }
}