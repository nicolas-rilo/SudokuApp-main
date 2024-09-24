using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.SudokuApp.Model.SudokuService;
using Es.Udc.DotNet.SudokuApp.Web.HTTP.Session;

namespace Es.Udc.DotNet.SudokuApp.Web.Pages.Sudoku
{
    //https://www.youtube.com/watch?v=mRZPY2RyGrU&ab_channel=hdeleon.net
    public partial class ResolveSudoku : SpecificCulturePage
    {
        public static Stopwatch sw;
        SudokuDto sudokuDto;
        List<ThermoDto> thermoDtos;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExplanation.Visible = false;
            btnAccept.Visible = false;
            Table2.Visible = false;
            lblSudokuExp.Visible = false;
            lclReview.Visible = false;
            DbdReview.Visible = false;

            if (SessionManager.IsUserAuthenticated(Context) && Request.QueryString["tournament"] == "true")
            {
                try
                {
                    SessionManager.getUserPosition(Context, long.Parse(Request.QueryString["tournamentId"]));
                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));

                }
                catch (ModelUtil.Exceptions.InstanceNotFoundException) {


                }

            }

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
                sw = new Stopwatch();
                sw.Start();
                if (Request.QueryString["dificulty"] != null)
                {
                    sudokuDto = SessionManager.generateSudoku(Context, Convert.ToInt32(Request.QueryString["dificulty"]));
                }
                else {
                    List<SudokuDto> sudokuDtos = SessionManager.findSudoku(Context, long.Parse(Request.QueryString["id"]));
                    sudokuDto = sudokuDtos[0];
                    thermoDtos = SessionManager.getThermos(Context, long.Parse(Request.QueryString["id"]));

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
                        if(sudokuDto.image != null) {
                            if (sudokuDto.image[i, j] != 0)
                            {
                                textBox.CssClass = "image" + sudokuDto.image[i, j];
                            }

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


                if (thermoDtos != null)
                {
                    foreach (ThermoDto a in thermoDtos)
                    {
                        TextBox textBox = (TextBox)Table1.FindControl("cell" + "-" + a.startCell.Item1 + "-" + a.startCell.Item2);
                        textBox.CssClass = "image1";
                        TextBox textBox1 = (TextBox)Table1.FindControl("cell" + "-" + a.endCell.Item1 + "-" + a.endCell.Item2);
                        textBox1.CssClass = "image3";

                        TextBox textBox2 = (TextBox)Table1.FindControl("cellT2" + "-" + a.startCell.Item1 + "-" + a.startCell.Item2);
                        textBox2.CssClass = "image1";
                        TextBox textBox3 = (TextBox)Table1.FindControl("cellT2" + "-" + a.endCell.Item1 + "-" + a.endCell.Item2);
                        textBox3.CssClass = "image3";

                    }
                }
            }

        }
        protected void tm1_Tick(object sender, EventArgs e)
        {
            long sec = sw.Elapsed.Seconds;
            long min = sw.Elapsed.Minutes;
            long hour = sw.Elapsed.Hours;

            if (hour < 10)
                Label1.Text = "0" + hour;
            else
                Label1.Text = hour.ToString();

            Label1.Text += " : ";
            
            if (min < 10)
                Label1.Text += "0" + min;
            else
                Label1.Text = min.ToString();

            Label1.Text += " : ";

            if (sec < 10)
                Label1.Text += "0" + sec;
            else
                Label1.Text += sec.ToString();
            
        }

        protected void validateSolution(object sender, EventArgs e)
        {
            char[] delimiterChars = {':'};

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
                btnSolve.Visible = false;

                if (SessionManager.IsUserAuthenticated(Context) && Request.QueryString["tournament"] != "true") {
                    lclReview.Visible = true;
                    DbdReview.Visible = true;
                }
                sw.Stop();
                if (Request.QueryString["tournament"] == "true" && Label1.ForeColor != Color.Red)
                {
                    string[] words = Label1.Text.Split(delimiterChars);
                    TimeSpan timeSpan = new TimeSpan(int.Parse(words[0]), int.Parse(words[1]),int.Parse(words[2]));
                    
                    SessionManager.participate(Context,long.Parse (Request.QueryString["tournamentId"]),timeSpan);
                }
            }
            else {
                if (Request.QueryString["tournament"] == "true")
                {
                    sw.Stop();
                    Label1.ForeColor = Color.Red;

                }
            } 
        }


        protected void endSudoku(object sender, EventArgs e)
        {
            if (SessionManager.IsUserAuthenticated(Context) && Request.QueryString["tournament"] != "true") {
                SessionManager.reviewSudoku(Context, long.Parse(Request.QueryString["id"]),int.Parse (DbdReview.SelectedValue));
            }
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));

        }
    }
}