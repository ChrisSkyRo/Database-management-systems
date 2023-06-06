using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lab1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        int selectedSurvivorID;

        public Form1()
        {
            InitializeComponent();
            parentView.ReadOnly = true;
            parentView.AllowUserToAddRows = false;
            childView.ReadOnly = true;
            childView.AllowUserToAddRows = false;
            AddButton.Enabled = false;
            KeyPreview = true;
            AddButton.Text = ConfigurationManager.AppSettings["AddTitle"];
            ChildLabel.Text = ConfigurationManager.AppSettings["ChildTable"];
            ParentLabel.Text = ConfigurationManager.AppSettings["ParentTable"];
        }

        private void ConnectDB_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);

            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There was an error connecting to the Database. Please contact the app administrator.");
                return;
            }

            sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["ParentSelectQuery"], con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            parentView.DataSource = ds.Tables[0];

            ConnectDB.Enabled = false;

            con.Close();
        }

        private void parentView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewCell selectedCell = parentView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
            {
                AddButton.Enabled = false;
                return;
            }

            AddButton.Enabled = true;
            selectedSurvivorID = Convert.ToInt32(selectedCell.Value);
            con.Open();
            sda.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildSelectQuery"] + selectedCell.Value.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            childView.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow(selectedSurvivorID, con, sda);
            addWindow.ShowDialog();

            con.Open();
            sda.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildSelectQuery"] + selectedSurvivorID.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            childView.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            else if (e.KeyCode == Keys.Enter)
            {
                if (ConnectDB.Enabled)
                    ConnectDB.PerformClick();
                else if (AddButton.Enabled)
                    AddButton.PerformClick();
            }
        }

        private void childView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewCell selectedCell = childView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
                return;

            string[] fields = new string[int.Parse(ConfigurationManager.AppSettings["ChildColumnsCount"])];
            string[] values = new string[int.Parse(ConfigurationManager.AppSettings["ChildColumnsCount"])];
            for (int i = 0; i < int.Parse(ConfigurationManager.AppSettings["ChildColumnsCount"]); i++)
            {
                values[i] = childView.Rows[e.RowIndex].Cells[i].Value.ToString();
            }
            ModifyWindow modifyWindow = new ModifyWindow(con, sda, values);
            modifyWindow.ShowDialog();

            con.Open();
            sda.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildSelectQuery"] + selectedSurvivorID.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            childView.DataSource = ds.Tables[0];
            con.Close();

        }

        private void parentView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }

        private void parentView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State == ConnectionState.Open)
                return;

            DataGridViewCell selectedCell = parentView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
            {
                AddButton.Enabled = false;
                return;
            }


            AddButton.Enabled = true;
            selectedSurvivorID = Convert.ToInt32(selectedCell.Value);
            con.Open();
            sda.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildSelectQuery"] + selectedCell.Value.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            childView.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}