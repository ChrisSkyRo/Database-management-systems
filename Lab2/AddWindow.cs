using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        int PID;
        TextBox[] textBoxes = new TextBox[5];
        int tbLen = 0;
        public AddWindow(int parentID, SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter)
        {
            InitializeComponent();
            // change window title
            this.Text = ConfigurationManager.AppSettings["AddTitle"];

            // add window contents
            int left = 70;
            int top = 10;
            for (int i = 1; i < int.Parse(ConfigurationManager.AppSettings["ChildColumnsCount"]); i++)
            {
                Label label = new Label();
                label.Text = ConfigurationManager.AppSettings["Label" + i.ToString()] + ": ";
                if (i == 1)
                    label.Text += parentID;
                label.Left = left;
                label.Top = top;
                label.Font = new Font("Arial", 15.75f);
                label.AutoSize = true;
                this.Controls.Add(label);

                if (i > 1)
                {
                    TextBox textBox = new TextBox();
                    textBox.Top = top + 40;
                    textBox.Left = left;
                    textBox.Width = 500;
                    textBox.KeyPress += TextBox_KeyPress;
                    if(i == 1)
                        textBox.Text = parentID.ToString();
                    this.Controls.Add(textBox);
                    textBoxes[tbLen] = textBox;
                    tbLen++;
                }
                top += 90;
            }

            PID = parentID;
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
            sda.InsertCommand = new SqlCommand(ConfigurationManager.AppSettings["ChildInsertQuery"], con);
            sda.InsertCommand.Parameters.AddWithValue("@pid", PID);
            for (int i = 0; i < tbLen; i++)
            {
                sda.InsertCommand.Parameters.AddWithValue("@l" + i.ToString(), textBoxes[i].Text);
            }
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
                if (textBoxes[tbLen - 1].Focused)
                    addBtn.PerformClick();
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
    }
}
