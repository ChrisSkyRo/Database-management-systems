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
            survivorsView.ReadOnly = true;
            survivorsView.AllowUserToAddRows = false;
            crimesView.ReadOnly = true;
            crimesView.AllowUserToAddRows = false;
            AddButton.Enabled = false;
            KeyPreview = true;
        }

        private void ConnectDB_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=SKY-PC;Initial Catalog=EarthNew;Integrated Security=True");

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
            sda.SelectCommand = new SqlCommand("SELECT * FROM Survivors", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            survivorsView.DataSource = ds.Tables[0];

            ConnectDB.Enabled = false;

            con.Close();
        }

        private void survivorsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = survivorsView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
            {
                AddButton.Enabled = false;
                return;
            }

            AddButton.Enabled = true;
            selectedSurvivorID = Convert.ToInt32(selectedCell.Value);
            con.Open();
            sda.SelectCommand = new SqlCommand("SELECT * FROM Crimes WHERE survivor_id=" + selectedCell.Value.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            crimesView.DataSource = ds.Tables[0];
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
            sda.SelectCommand = new SqlCommand("SELECT * FROM Crimes WHERE survivor_id=" + selectedSurvivorID.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            crimesView.DataSource = ds.Tables[0];
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

        private void crimesView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = crimesView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
                return;

            string survivorID, crimeDesc, punishment;
            survivorID = crimesView.Rows[e.RowIndex].Cells[1].Value.ToString();
            crimeDesc = crimesView.Rows[e.RowIndex].Cells[2].Value.ToString();
            punishment = crimesView.Rows[e.RowIndex].Cells[3].Value.ToString();
            ModifyWindow modifyWindow = new ModifyWindow(Convert.ToInt32(selectedCell.Value), con, sda, survivorID, crimeDesc, punishment);
            modifyWindow.ShowDialog();

            con.Open();
            sda.SelectCommand = new SqlCommand("SELECT * FROM Crimes WHERE survivor_id=" + selectedSurvivorID.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            crimesView.DataSource = ds.Tables[0];
            con.Close();

        }

        private void survivorsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }

        private void survivorsView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State == ConnectionState.Open)
                return;

            DataGridViewCell selectedCell = survivorsView.Rows[e.RowIndex].Cells[0];

            if (selectedCell == null)
            {
                AddButton.Enabled = false;
                return;
            }


            AddButton.Enabled = true;
            selectedSurvivorID = Convert.ToInt32(selectedCell.Value);
            con.Open();
            sda.SelectCommand = new SqlCommand("SELECT * FROM Crimes WHERE survivor_id=" + selectedCell.Value.ToString(), con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            crimesView.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}