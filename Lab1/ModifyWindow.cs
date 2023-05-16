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
    public partial class ModifyWindow : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        int CID;
        public ModifyWindow(int crimeID, SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter, string survivorID, string crimeDesc, string punishment)
        {
            InitializeComponent();
            crimeIDLabel.Text += crimeID.ToString();
            survivorIDTextBox.Text = survivorID;
            crimeDescTextBox.Text = crimeDesc;
            punishmentTextBox.Text = punishment;
            CID = crimeID;
            con = sqlConnection;
            sda = sqlDataAdapter;
            KeyPreview = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancelBtn.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (survivorIDTextBox.Focused)
                    crimeDescTextBox.Focus();
                else if (crimeDescTextBox.Focused)
                    punishmentTextBox.Focus();
                else updateBtn.PerformClick();
            }
        }

        private void survivorIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            sda.DeleteCommand = new SqlCommand("DELETE FROM Crimes WHERE crime_id=@cid", con);
            sda.DeleteCommand.Parameters.AddWithValue("@cid", CID);
            sda.DeleteCommand.ExecuteNonQuery();
            con.Close();
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (survivorIDTextBox.TextLength == 0 || crimeDescTextBox.TextLength == 0 || punishmentTextBox.TextLength == 0) 
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Survivor ID, crime description and punishment can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();
            sda.UpdateCommand = new SqlCommand("UPDATE Crimes SET survivor_id=@sid, crime_description=@cd, punishment=@p WHERE crime_id=@cid", con);
            sda.UpdateCommand.Parameters.AddWithValue("@cd", crimeDescTextBox.Text);
            sda.UpdateCommand.Parameters.AddWithValue("@sid", int.Parse(survivorIDTextBox.Text));
            sda.UpdateCommand.Parameters.AddWithValue("@p", punishmentTextBox.Text);
            sda.UpdateCommand.Parameters.AddWithValue("@cid", CID);
            sda.UpdateCommand.ExecuteNonQuery();
            con.Close();
            this.Close();
        }
    }
}
