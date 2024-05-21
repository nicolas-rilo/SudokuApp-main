using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.SudokuApp.Web.HTTP.View
{
    public class Countries
    {
        private static readonly ArrayList countries_es = new ArrayList();
        private static readonly ArrayList countries_en = new ArrayList();
        private static readonly ArrayList countries_gl = new ArrayList();
        private static readonly ArrayList countrieCodes = new ArrayList();
        private static readonly Hashtable countries = new Hashtable();


        
        private Countries() { }

        static Countries()
        {
            #region set the countries

            countries_es.Add(new ListItem("España", "ES"));
            countries_es.Add(new ListItem("Estados Unidos", "US"));
            countries_es.Add(new ListItem("Reino Unido", "UK"));

            countries_en.Add(new ListItem("Spain", "ES"));
            countries_en.Add(new ListItem("United Kingdom", "UK"));
            countries_en.Add(new ListItem("United States", "US"));

            countries_gl.Add(new ListItem("España", "ES"));
            countries_gl.Add(new ListItem("Estados Unidos", "US"));
            countries_gl.Add(new ListItem("Reino Unido", "UK"));

            countrieCodes.Add("ES");
            countrieCodes.Add("UK");
            countrieCodes.Add("US");

            countries.Add("es", countries_es);
            countries.Add("en", countries_en);
            countries.Add("gl", countries_gl);

            #endregion

        }

        public static ICollection GetCountryCodes()
        {
            return countrieCodes;
        }

        public static ArrayList GetCountries(String languageCode)
        {
            ArrayList lang = (ArrayList)countries[languageCode];

            if (lang != null)
            {
                return lang;
            }
            else
            {
                return (ArrayList)countries["en"];
            }
        }
    }
}