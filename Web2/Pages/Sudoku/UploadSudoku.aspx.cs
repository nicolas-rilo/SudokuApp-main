using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku
{
    public partial class UploadSudoku : SpecificCulturePage
    {
        public static List<ThermoDto> UThermo = new List<ThermoDto>();
        protected void Page_Load(object sender, EventArgs e)
        {
 

            if (!SessionManager.IsUserAuthenticated(Context)) {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/LogIn.aspx"));
            }

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

            
            long sudokuid = SessionManager.uploadSudoku(Context, txtSudokuName.Text, txtSudokuRules.Text, DdDificulty.SelectedValue, checkNormal.Checked,checkKiller.Checked,
                checkThermal.Checked,checkArrow.Checked,checkCustom.Checked,puzzle,solution);

            foreach (ThermoDto a in UThermo) {
                SessionManager.uploadThermo(Context,sudokuid,a.startCell,a.endCell,a.cells);
            }
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

        protected void CreateThermo(object sender, EventArgs e) {

            char[] delimiterChars = { ' ', '/', '.', ':', '\t', '-' };

            string[] words = txtThermoS.Text.Split(delimiterChars);
            string[] words1 = txtThermoE.Text.Split(delimiterChars);



            (int, int) a = (int.Parse(words[0]) -1, int.Parse(words[1]) -1);
            (int, int) b = (int.Parse(words1[0]) - 1, int.Parse(words1[1]) - 1);

            if (UThermo != null)
            {
                foreach (ThermoDto t in UThermo)
                {
                    if (t.startCell == a|| t.startCell == b || t.endCell == b || t.endCell == a ) {
                        return;
                    }
                }
            }


            TextBox textBox = (TextBox)Table1.FindControl("cell" + "-" + a.Item1 + "-" + a.Item2);
            textBox.CssClass = "image1";
            TextBox textBox1 = (TextBox)Table1.FindControl("cellT2" + "-" + a.Item1 + "-" + a.Item2);
            textBox1.CssClass = "image1";

            TextBox textBox2 = (TextBox)Table1.FindControl("cell" + "-" + b.Item1 + "-" + b.Item2);
            textBox2.CssClass = "image3";
            TextBox textBox3 = (TextBox)Table1.FindControl("cellT2" + "-" + b.Item1 + "-" + b.Item2);
            textBox3.CssClass = "image3";
            ThermoDto thermoDto = new ThermoDto(-1,a,b,null);
            UThermo.Add(thermoDto);
        }
        protected void AddPath(object sender, EventArgs e)
        {
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            TextBox textBox = new TextBox();
            Label label = new Label();
            label.Text = "path" + c.ColumnSpan;
            c.Controls.Add(label);
            c.Controls.Add(textBox);

            r.Controls.Add(c);
            ThermoPath.Rows.Add(r);

        }

    }
}