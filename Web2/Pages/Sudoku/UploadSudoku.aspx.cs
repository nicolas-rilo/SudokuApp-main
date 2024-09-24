using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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





            for (int i = 0; i < 9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++)
                {
                    TableCell c = new TableCell();
                    DropDownList dropDown = new DropDownList();

                    DataTable objdt = new DataTable();
                    objdt = GetData();
                    dropDown.DataSource = objdt;
                    dropDown.DataTextField = "Figure";
                    dropDown.DataValueField = "Id";
                    dropDown.DataBind();
  

                    dropDown.CssClass = "cell2";
                    dropDown.ID = "check-" + i + "-" + j;

                    c.Controls.Add(dropDown);
                    r.Controls.Add(c);

                }
                ThermoPath.Rows.Add(r);

            }

            for (int i = 0; i < 9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++)
                {
                    TableCell c = new TableCell();
                    DropDownList dropDown = new DropDownList();

                    DataTable objdt = new DataTable();
                    objdt = GetDataArrow();
                    dropDown.DataSource = objdt;
                    dropDown.DataTextField = "Figure";
                    dropDown.DataValueField = "Id";
                    dropDown.DataBind();


                    dropDown.CssClass = "cell2";
                    dropDown.ID = "checkT2-" + i + "-" + j;

                    c.Controls.Add(dropDown);
                    r.Controls.Add(c);

                }
                ArrowPath.Rows.Add(r);

            }

            for (int i = 0; i < 9; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < 9; j++)
                {
                    TableCell c = new TableCell();
                    DropDownList dropDown = new DropDownList();

                    DataTable objdt = new DataTable();
                    objdt = GetDataArrow();
                    dropDown.DataSource = objdt;
                    dropDown.DataTextField = "Figure";
                    dropDown.DataValueField = "Id";
                    dropDown.DataBind();


                    dropDown.CssClass = "cell2";
                    dropDown.ID = "checkT3-" + i + "-" + j;

                    c.Controls.Add(dropDown);
                    r.Controls.Add(c);

                }
                KillerPath.Rows.Add(r);

            }

            lclSolution.Visible = false;
            btnCreate.Visible = false;
            btnCreate2.Visible = false;
            btnCreate3.Visible = false;
            btnSwitch2.Visible = false;
            Table2.Visible = false;
            ThermoPath.Visible = false;
            ArrowPath.Visible = false;
            KillerPath.Visible = false;


            btnAddPath.Visible = true;
            btnAddArrow.Visible = true;
            btnAddKiller.Visible = true;


        }


        public DataTable GetData()
        {
            DataTable _objdt = new DataTable();

            _objdt.Columns.Add("Figure", typeof(string));
            _objdt.Columns.Add("Id", typeof(long));

            _objdt.Columns.Add("LabelValue");
            var _objrow = _objdt.NewRow();
            _objrow["Figure"] = "";
            _objrow["Id"] = 1;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "╗"; 
            _objrow["Id"] = 2;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "╝";
            _objrow["Id"] = 3;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "╚";
            _objrow["Id"] = 4;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "╔";
            _objrow["Id"] = 5;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "║";
            _objrow["Id"] = 6;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "═";
            _objrow["Id"] = 7;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "O";
            _objrow["Id"] = 8;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "→";
            _objrow["Id"] = 9;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "←";
            _objrow["Id"] = 10;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "↑";
            _objrow["Id"] = 11;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "↓";
            _objrow["Id"] = 12;
            _objdt.Rows.Add(_objrow);
            return _objdt;
        }


        public DataTable GetDataArrow()
        {
            DataTable _objdt = new DataTable();

            _objdt.Columns.Add("Figure", typeof(string));
            _objdt.Columns.Add("Id", typeof(long));

            _objdt.Columns.Add("LabelValue");
            var _objrow = _objdt.NewRow();
            _objrow["Figure"] = "";
            _objrow["Id"] = 1;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "┐";
            _objrow["Id"] = 2;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "┘";
            _objrow["Id"] = 3;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "└";
            _objrow["Id"] = 4;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "┌";
            _objrow["Id"] = 5;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "│";
            _objrow["Id"] = 6;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "─";
            _objrow["Id"] = 7;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "O";
            _objrow["Id"] = 8;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "→";
            _objrow["Id"] = 9;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "←";
            _objrow["Id"] = 10;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "↑";
            _objrow["Id"] = 11;
            _objdt.Rows.Add(_objrow);

            _objrow = _objdt.NewRow();
            _objrow["Figure"] = "↓";
            _objrow["Id"] = 12;
            _objdt.Rows.Add(_objrow);

            return _objdt;
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

        protected int[,] getImagesFromTable(Table table, String cellName)
        {
            int[,] value = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textBox = (TextBox)Table1.FindControl(cellName + "-" + i + "-" + j);
                    if (textBox.CssClass != "cell")
                    {
                        string image = textBox.CssClass;
                        if (image.Length == 6)
                        {
                            value[i, j] = Int32.Parse("" + image[5]);
                        }
                        else {
                            value[i, j] = Int32.Parse("" + image[5]+image[6]);
                        }
                    }
                    else
                    {
                        value[i, j] = 0;
                    }

                }


            }

            return value;
        }

        bool validateSolution() {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textBox = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);

                    result = (textBox.Text != "") && result; 
                
                }
            }
            return result;
        }
        protected void uploadSudoku(object sender, EventArgs e)
        {
            int[,] puzzle = getValuesFromTable(Table1, "cell");
            int[,] solution = getValuesFromTable(Table2, "cellT2");
            int[,] images = getImagesFromTable(Table1, "cell");

            if (!validateSolution()) {
                lclSolution.Visible = true;
                return;
            }



            long sudokuid = SessionManager.uploadSudoku(Context, txtSudokuName.Text, txtSudokuRules.Text, DdDificulty.SelectedValue, checkNormal.Checked,checkKiller.Checked,
                checkThermal.Checked,checkArrow.Checked,checkCustom.Checked,puzzle,solution,images);

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

            TextBox textBox = new TextBox();
            TextBox textBox1 = new TextBox();
            String image = null;
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    DropDownList dropDown = (DropDownList)ThermoPath.FindControl("check-" + i + "-" + j);
                    switch (dropDown.SelectedIndex) {
                        case 0: break;
                        case 1:
                            image = "image4"; break;
                        case 2:
                            image = "image5"; break;
                        case 3:
                            image = "image8"; break;
                        case 4:
                            image = "image7"; break;
                        case 5:
                            image = "image6"; break;
                        case 6:
                            image = "image2"; break;
                        case 7:
                            image = "image1"; break;
                        case 8:
                            image = "image3"; break;
                        case 9:
                            image = "image17"; break;
                        case 10:
                            image = "image18"; break;
                        case 11:
                            image = "image16"; break;
                        default: break;

                    }
                    if (image != null)
                    {

                        textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                        textBox.CssClass = image;
                        textBox1 = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);
                        textBox1.CssClass = image;
                        DropDownList dropDownOtro = (DropDownList)ThermoPath.FindControl("checkT2-" + i + "-" + j);
                        dropDownOtro.Enabled = false;
                        dropDownOtro.BackColor = Color.Gray;

                        image = null;
                    }
                    else {
                        textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                        if(dropDown.Enabled)
                            textBox.CssClass = "cell";
                        textBox1 = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);
                        if (dropDown.Enabled)
                            textBox1.CssClass = "cell";
                        DropDownList dropDownOtro = (DropDownList)ThermoPath.FindControl("checkT2-" + i + "-" + j);
                        dropDownOtro.Enabled = true;
                        dropDownOtro.BackColor = Color.White;

                    }
                }
            }





            /*ThermoDto thermoDto = new ThermoDto(-1,a,b,null);
            UThermo.Add(thermoDto);*/

        }
        protected void AddPath(object sender, EventArgs e)
        {
            ThermoPath.Visible = true;
            btnAddPath.Visible = false;
            btnCreate.Visible = true;

            btnAddKiller.Visible = false;
            btnAddArrow.Visible = false;

        }

        protected void CreateArrow(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            TextBox textBox1 = new TextBox();
            String image = null;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    DropDownList dropDown = (DropDownList)ThermoPath.FindControl("checkT2-" + i + "-" + j);
                    switch (dropDown.SelectedIndex)
                    {
                        case 0: break;
                        case 1:
                            image = "image11"; break;
                        case 2:
                            image = "image12"; break;
                        case 3:
                            image = "image15"; break;
                        case 4:
                            image = "image14"; break;
                        case 5:
                            image = "image13"; break;
                        case 6:
                            image = "image9"; break;
                        case 7:
                            image = "image1"; break;
                        case 8:
                            image = "image10"; break;
                        case 9:
                            image = "image20"; break;
                        case 10:
                            image = "image21"; break;
                        case 11:
                            image = "image19"; break;
                        default: break;

                    }
                    if (image != null)
                    {

                        textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                        textBox.CssClass = image;
                        textBox1 = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);
                        textBox1.CssClass = image;
                        DropDownList dropDownOtro = (DropDownList)ThermoPath.FindControl("check-" + i + "-" + j);
                        dropDownOtro.Enabled = false;
                        dropDownOtro.BackColor = Color.Gray;
                        image = null;
                    }
                    else
                    {
                        textBox = (TextBox)Table1.FindControl("cell" + "-" + i + "-" + j);
                        if (dropDown.Enabled)
                            textBox.CssClass = "cell";
                        textBox1 = (TextBox)Table2.FindControl("cellT2" + "-" + i + "-" + j);
                        if (dropDown.Enabled)
                            textBox1.CssClass = "cell";
                        DropDownList dropDownOtro = (DropDownList)ThermoPath.FindControl("check-" + i + "-" + j);
                        dropDownOtro.Enabled = true;
                        dropDownOtro.BackColor = Color.White;

                    }
                }
            }

        }

        protected void AddArrow(object sender, EventArgs e)
        {
            ArrowPath.Visible = true;
            btnAddArrow.Visible = false;
            btnCreate2.Visible = true;

            btnAddKiller.Visible = false;
            btnAddPath.Visible = false;

        }

        protected void AddKiller(object sender, EventArgs e)
        {
            KillerPath.Visible = true;
            btnAddKiller.Visible = false;
            btnCreate3.Visible = true;

            btnAddArrow.Visible = false;
            btnAddPath.Visible = false;

        }
        protected void CreateKiller(object sender, EventArgs e)
        {


        }

    }
}