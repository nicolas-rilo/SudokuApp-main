using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages
{
    public partial class Home : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context,null,null,false,false,false,false,0,8);
 
 
             Repeater1.DataSource = sudokuDtos;
             Repeater1.DataBind();

        }

        protected void resultNormal(object sender, EventArgs e) {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null, false, false, false, false, 0, 8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }
        protected void resultCustom(object sender, EventArgs e)
        {
            List<SudokuDto> sudokuDtos = SessionManager.findByFilter(Context, null, null, false, false, false, true, 0, 8);


            Repeater1.DataSource = sudokuDtos;
            Repeater1.DataBind();
        }

    }

}