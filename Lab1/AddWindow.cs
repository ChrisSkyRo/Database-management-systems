using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class AddWindow : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        int SID;
        public AddWindow(int survivorID, SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter)
        {
            InitializeComponent();
            survivorIDLabel.Text += survivorID.ToString();
            SID = survivorID;
            con = sqlConnection;
            sda = sqlDataAdapter;
            KeyPreview = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (crimeDescBox.TextLength == 0 || punishmentBox.TextLength == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Insert a valid crime description and punishment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();
            sda.InsertCommand = new SqlCommand("INSERT INTO Crimes(survivor_id, crime_description, punishment)" +
                "VALUES (@sid, @cd, @p)", con);
            sda.InsertCommand.Parameters.AddWithValue("@sid", SID);
            sda.InsertCommand.Parameters.AddWithValue("@cd", crimeDescBox.Text);
            sda.InsertCommand.Parameters.AddWithValue("@p", punishmentBox.Text);
            sda.InsertCommand.ExecuteNonQuery();
            con.Close();

            this.Close();
        }

        private void AddWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelBtn.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (crimeDescBox.Focused)
                    punishmentBox.Focus();
                else
                    addBtn.PerformClick();
            }
        }

        private void crimeDescBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }

        private void punishmentBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }
    }
}
