using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using Es.Udc.DotNet.ModelUtil.Log;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.View;

namespace Es.Udc.DotNet.SudokuApp.Web.HTTP.Session
{
    public class SpecificCulturePage: Page
    {
        protected override void InitializeCulture()
        {
            if (SessionManager.IsUserAuthenticated(Context))
            {
                Locale locale = SessionManager.GetLocale(Context);

                String culture = locale.Language + "-" + locale.Country;
                CultureInfo cultureInfo;
                try
                {
                    cultureInfo = new CultureInfo(culture);

                    LogManager.RecordMessage("Specific culture created: " + cultureInfo.Name, MessageType.Info);
                }
                
                catch (ArgumentException)
                {
                    cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                    LogManager.RecordMessage("Default Specific culture created: " + cultureInfo.Name, MessageType.Info);
                }

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}