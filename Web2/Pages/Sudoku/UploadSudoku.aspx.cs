using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku
{
    public partial class UploadSudoku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int i = 0; i <9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++) {
                    TableCell c = new TableCell();
                    TextBox textBox = new TextBox();
                    textBox.CssClass = "cell";
                    textBox.ID = "cell-"+i+"-"+j;
                    textBox.TextMode = TextBoxMode.Number;

                    c.Controls.Add(textBox);
                    r.Controls.Add(c);
                    
                }
                Table1.Rows.Add(r);
               
            }
        }
        protected void uploadSudoku(object sender, EventArgs e)
        {
            int[,] puzzle = new int[9,9];

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    TextBox textBox = (TextBox)Table1.FindControl("cell-"+i+"-"+j);
                    if (textBox.Text != "")
                    {
                        puzzle[i, j] = Int32.Parse(textBox.Text);
                    }
                    else {
                        puzzle[i, j] = 0;
                    } 

                }


            }


            int[,] solution  = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }           
            }; 

            SessionManager.uploadSudoku(Context,"prueba","rules","Easy",checkNormal.Checked,checkKiller.Checked,
                checkThermal.Checked,checkArrow.Checked,checkCustom.Checked,puzzle,solution);
        }
    }
}