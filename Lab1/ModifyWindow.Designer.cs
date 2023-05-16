namespace Lab1
{
    partial class ModifyWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            crimeIDLabel = new Label();
            survivorIDLabel = new Label();
            crimeDescLabel = new Label();
            punishmentLabel = new Label();
            survivorIDTextBox = new TextBox();
            crimeDescTextBox = new TextBox();
            punishmentTextBox = new TextBox();
            updateBtn = new Button();
            deleteBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // crimeIDLabel
            // 
            crimeIDLabel.AutoSize = true;
            crimeIDLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            crimeIDLabel.Location = new Point(70, 44);
            crimeIDLabel.Name = "crimeIDLabel";
            crimeIDLabel.Size = new Size(104, 24);
            crimeIDLabel.TabIndex = 0;
            crimeIDLabel.Text = "Crime ID: ";
            // 
            // survivorIDLabel
            // 
            survivorIDLabel.AutoSize = true;
            survivorIDLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            survivorIDLabel.Location = new Point(70, 94);
            survivorIDLabel.Name = "survivorIDLabel";
            survivorIDLabel.Size = new Size(121, 24);
            survivorIDLabel.TabIndex = 1;
            survivorIDLabel.Text = "Survivor ID:";
            // 
            // crimeDescLabel
            // 
            crimeDescLabel.AutoSize = true;
            crimeDescLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            crimeDescLabel.Location = new Point(70, 180);
            crimeDescLabel.Name = "crimeDescLabel";
            crimeDescLabel.Size = new Size(179, 24);
            crimeDescLabel.TabIndex = 2;
            crimeDescLabel.Text = "Crime description:";
            // 
            // punishmentLabel
            // 
            punishmentLabel.AutoSize = true;
            punishmentLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            punishmentLabel.Location = new Point(70, 261);
            punishmentLabel.Name = "punishmentLabel";
            punishmentLabel.Size = new Size(124, 24);
            punishmentLabel.TabIndex = 3;
            punishmentLabel.Text = "Punishment:";
            // 
            // survivorIDTextBox
            // 
            survivorIDTextBox.Location = new Point(70, 131);
            survivorIDTextBox.Name = "survivorIDTextBox";
            survivorIDTextBox.Size = new Size(544, 23);
            survivorIDTextBox.TabIndex = 4;
            survivorIDTextBox.KeyPress += survivorIDTextBox_KeyPress;
            // 
            // crimeDescTextBox
            // 
            crimeDescTextBox.Location = new Point(70, 220);
            crimeDescTextBox.Name = "crimeDescTextBox";
            crimeDescTextBox.Size = new Size(544, 23);
            crimeDescTextBox.TabIndex = 5;
            crimeDescTextBox.KeyPress += survivorIDTextBox_KeyPress;
            // 
            // punishmentTextBox
            // 
            punishmentTextBox.Location = new Point(70, 299);
            punishmentTextBox.Name = "punishmentTextBox";
            punishmentTextBox.Size = new Size(544, 23);
            punishmentTextBox.TabIndex = 6;
            punishmentTextBox.KeyPress += survivorIDTextBox_KeyPress;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(70, 378);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(118, 56);
            updateBtn.TabIndex = 7;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(283, 378);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(117, 56);
            deleteBtn.TabIndex = 8;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(499, 378);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 56);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // ModifyWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 498);
            Controls.Add(cancelBtn);
            Controls.Add(deleteBtn);
            Controls.Add(updateBtn);
            Controls.Add(punishmentTextBox);
            Controls.Add(crimeDescTextBox);
            Controls.Add(survivorIDTextBox);
            Controls.Add(punishmentLabel);
            Controls.Add(crimeDescLabel);
            Controls.Add(survivorIDLabel);
            Controls.Add(crimeIDLabel);
            Name = "ModifyWindow";
            Text = "Modify Crime";
            KeyDown += ModifyWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label crimeIDLabel;
        private Label survivorIDLabel;
        private Label crimeDescLabel;
        private Label punishmentLabel;
        private TextBox survivorIDTextBox;
        private TextBox crimeDescTextBox;
        private TextBox punishmentTextBox;
        private Button updateBtn;
        private Button deleteBtn;
        private Button cancelBtn;
    }
}