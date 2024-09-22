using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.User
{
    public partial class Profile : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserDetails userDetails = SessionManager.FindUserDetails(Context);


            lblUsername.Text = userDetails.userName;
            lblFirstName.Text = userDetails.firstName;
            lblLastName.Text = userDetails.lastName;

            List<SudokuDto> sudokuDtos = SessionManager.findSudokusByUser(Context, 0, 8);

            Repeater2.DataSource = sudokuDtos;
            Repeater2.DataBind();

        }
        protected void EditSudoku(object sender, EventArgs e)
        {

        }
    }
}