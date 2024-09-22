using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.ModelUtil.Log;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.View;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.User
{
    public partial class ModifyProfile : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String defaultLanguage =
                    GetLanguageFromBrowserPreferences();
                String defaultCountry =
                    GetCountryFromBrowserPreferences();

                UpdateComboLanguage(defaultLanguage);
                UpdateComboCountry(defaultLanguage, defaultCountry);

                UserDetails userDetails = SessionManager.FindUserDetails(Context);

                txtLogin.Text = userDetails.userName;
                txtFirstName.Text = userDetails.firstName;
                txtLastName.Text = userDetails.lastName;
                txtEmail.Text = userDetails.Email;
                comboCountry.SelectedValue = userDetails.country;
                comboLanguage.SelectedValue = userDetails.idiom;
            }
        }

        protected void ModifyData(object sender, EventArgs e)
        {
            UserDetails user = new UserDetails(txtLogin.Text,txtFirstName.Text,txtLastName.Text,txtEmail.Text, comboLanguage.SelectedValue, comboCountry.SelectedValue);
            SessionManager.UpdateUserProfileDetails(Context, user);
           
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/Profile.aspx"));
        }

        private String GetLanguageFromBrowserPreferences()
        {
            String language;
            CultureInfo cultureInfo =
                CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
            language = cultureInfo.TwoLetterISOLanguageName;
            LogManager.RecordMessage("Preferred language of user" +
                                     " (based on browser preferences): " + language);
            return language;
        }

        private String GetCountryFromBrowserPreferences()
        {
            String country;
            CultureInfo cultureInfo =
                CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);

            if (cultureInfo.IsNeutralCulture)
            {
                country = "";
            }
            else
            {
                String cultureInfoName = cultureInfo.Name;
                country = cultureInfoName.Substring(cultureInfoName.Length - 2);

                LogManager.RecordMessage("Preferred region/country of user " +
                                         "(based on browser preferences): " + country);
            }

            return country;
        }
        private void UpdateComboLanguage(String selectedLanguage)
        {
            this.comboLanguage.DataSource = Languages.GetLanguages(selectedLanguage);
            this.comboLanguage.DataTextField = "text";
            this.comboLanguage.DataValueField = "value";
            this.comboLanguage.DataBind();
            this.comboLanguage.SelectedValue = selectedLanguage;
        }


        private void UpdateComboCountry(String selectedLanguage, String selectedCountry)
        {
            this.comboCountry.DataSource = Countries.GetCountries(selectedLanguage);
            this.comboCountry.DataTextField = "text";
            this.comboCountry.DataValueField = "value";
            this.comboCountry.DataBind();
            this.comboCountry.SelectedValue = selectedCountry;
        }
        protected void ComboLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateComboCountry(comboLanguage.SelectedValue,
                comboCountry.SelectedValue);
        }

    }
}