using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        TextBox[] textBoxes = new TextBox[5];
        int tbLen = 0;
        public ModifyWindow(SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter, string[] values)
        {
            InitializeComponent();
            // change window title
            this.Text = ConfigurationManager.AppSettings["ModifyTitle"];

            // add Window Contents 
            int left = 70;
            int top = 10;
            for (int i = 0; i < int.Parse(ConfigurationManager.AppSettings["ChildColumnsCount"]); i++)
            {
                Label label = new Label();
                label.Text = ConfigurationManager.AppSettings["Label" + i.ToString()] + ": ";
                if (i == 0)
                    label.Text += values[0].ToString();
                label.Left = left;
                label.Top = top;
                label.Font = new Font("Arial", 15.75f);
                label.AutoSize = true;
                this.Controls.Add(label);

                if (i > 0)
                {
                    TextBox textBox = new TextBox();
                    textBox.Top = top + 40;
                    textBox.Left = left;
                    textBox.Width = 500;
                    textBox.Text = values[i].ToString();
                    textBox.KeyPress += TextBox_KeyPress;
                    this.Controls.Add(textBox);
                    textBoxes[tbLen] = textBox;
                    tbLen++;
                }
                top += 90;
            }

            CID = int.Parse(values[0]);
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
                if (textBoxes[tbLen - 1].Focused)
                    updateBtn.PerformClick();
                else
                {
                    for (int i = 0; i < tbLen - 1; i++)
                        if (textBoxes[i].Focused)
                        {
                            textBoxes[i + 1].Focus();
                            return;
                        }
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            sda.DeleteCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildDeleteQuery"], con);
            sda.DeleteCommand.Parameters.AddWithValue("@cid", CID);
            sda.DeleteCommand.ExecuteNonQuery();
            con.Close();
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            bool empty = false;
            for (int i = 0; i < tbLen; i++)
            {
                if (textBoxes[i].TextLength == 0) 
                {
                    empty = true;
                }
            }

            if (empty)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Fields can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            con.Open();
            sda.UpdateCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildUpdateQuery"], con);
            for (int i = 0; i < tbLen; i++)
            {
                sda.UpdateCommand.Parameters.AddWithValue("@l" + i.ToString(), textBoxes[i].Text);
            }
            sda.UpdateCommand.Parameters.AddWithValue("@cid", CID);
            sda.UpdateCommand.ExecuteNonQuery();
            con.Close();
            this.Close();
        }
    }
}
