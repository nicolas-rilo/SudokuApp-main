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
    public partial class ResolveSudoku : SpecificCulturePage
    {
        SudokuDto sudokuDto;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExplanation.Visible = false;
            btnAccept.Visible = false;
            Table2.Visible = false;
            lblSudokuExp.Visible = false;

            for (int i = 0; i < 9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++)
                {
                    TableCell c = new TableCell();
                    TextBox textBox = new TextBox();
                    textBox.CssClass = "cell";
                    textBox.ID = "cell-" + i + "-" + j;
                    textBox.TextMode = TextBoxMode.Number;
                    textBox.ForeColor = System.Drawing.Color.Gray;


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

            if (!IsPostBack) {
                if (Request.QueryString["dificulty"] != null)
                {
                    sudokuDto = SessionManager.generateSudoku(Context, Convert.ToInt32(Request.QueryString["dificulty"]));
                }
                else {
                    List<SudokuDto> sudokuDtos = SessionManager.findSudoku(Context, long.Parse(Request.QueryString["id"]));
                    sudokuDto = sudokuDtos[0];

                }
                
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        TextBox textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                        if (sudokuDto.puzzle[i, j] != 0)
                        {
                            textBox.Text = sudokuDto.puzzle[i, j].ToString();
                            textBox.Enabled = false;
                            textBox.ForeColor = System.Drawing.Color.Black ;
                        }
                        else
                        {
                            textBox.Text = "";
                        }
                        textBox.BackColor = System.Drawing.Color.White;

                    }


                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        TextBox textBox = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);

                        textBox.Text = sudokuDto.solution[i, j].ToString();
                        textBox.Enabled = false;
                    }
                }
                if (sudokuDto.rules != null) {
                    lblSudokuExp.Text =  sudokuDto.rules;
                    lblSudokuExp.Visible = true;
                }
            }

        }

        protected void validateSolution(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                    TextBox textBox2 = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);


                    if (textBox.Text == "" || (Convert.ToInt32(textBox2.Text) != Convert.ToInt32(textBox.Text)))
                    {
                        textBox.BackColor = System.Drawing.Color.Red;
                    }
                    else {
                        textBox.BackColor = System.Drawing.Color.White;
                        count++;
                    }
                }
            }

            if (count == 81) {
                lblExplanation.Visible = true;
                btnAccept.Visible = true;
            }
        }


        protected void endSudoku(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));

        }
    }
}