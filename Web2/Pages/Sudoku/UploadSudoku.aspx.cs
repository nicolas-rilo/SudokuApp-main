using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku
{
    public partial class UploadSudoku : SpecificCulturePage
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
            for (int i = 0; i < 9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++)
                {
                    TableCell c = new TableCell();
                    TextBox textBox = new TextBox();
                    textBox.CssClass = "cell";
                    textBox.ID = "cellT2-" + i + "-" + j;
                    textBox.TextMode = TextBoxMode.Number;

                    c.Controls.Add(textBox);
                    r.Controls.Add(c);

                }
                Table2.Rows.Add(r);

            }
            btnSwitch2.Visible = false;
            Table2.Visible = false;
        }


        protected int[,] getValuesFromTable(Table table, String cellName) {
            int[,] value = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textBox = (TextBox)Table1.FindControl(cellName+"-" + i + "-" + j);
                    if (textBox.Text != "")
                    {
                        value[i, j] = Int32.Parse(textBox.Text);
                    }
                    else
                    {
                        value[i, j] = 0;
                    }

                }


            }

            return value;
        }
        protected void uploadSudoku(object sender, EventArgs e)
        {
            int[,] puzzle = getValuesFromTable(Table1, "cell");
            int[,] solution = getValuesFromTable(Table2, "cellT2");

            
            SessionManager.uploadSudoku(Context, txtSudokuName.Text, txtSudokuRules.Text, DdDificulty.SelectedValue, checkNormal.Checked,checkKiller.Checked,
                checkThermal.Checked,checkArrow.Checked,checkCustom.Checked,puzzle,solution);
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));

        }

        protected void switchTable(object sender, EventArgs e) {

            if (Table1.Visible)
            {
                Table1.Visible = false;
                Table2.Visible = true;
                btnSwitch.Visible = false;
                btnSwitch2.Visible = true;


                int[,] table1Values = getValuesFromTable(Table1, "cell");
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        TextBox textBox = (TextBox)Table1.FindControl("cellT2" + "-" + i + "-" + j);
                        if(table1Values[i, j]!=0)
                            textBox.Text = ""+table1Values[i, j];

                    }
                }
            }
            else {
                Table1.Visible = true;
                Table2.Visible = false;
                btnSwitch.Visible = true;
                btnSwitch2.Visible = false;
            } 

        
        }

    }
}