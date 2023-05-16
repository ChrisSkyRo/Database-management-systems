namespace Lab1
{
    partial class AddWindow
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
            punishmentLabel = new Label();
            crimeDescriptionLabel = new Label();
            punishmentBox = new TextBox();
            crimeDescBox = new TextBox();
            survivorIDLabel = new Label();
            addBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // punishmentLabel
            // 
            punishmentLabel.AutoSize = true;
            punishmentLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            punishmentLabel.Location = new Point(66, 173);
            punishmentLabel.Name = "punishmentLabel";
            punishmentLabel.Size = new Size(124, 24);
            punishmentLabel.TabIndex = 13;
            punishmentLabel.Text = "Punishment:";
            // 
            // crimeDescriptionLabel
            // 
            crimeDescriptionLabel.AutoSize = true;
            crimeDescriptionLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            crimeDescriptionLabel.Location = new Point(66, 90);
            crimeDescriptionLabel.Name = "crimeDescriptionLabel";
            crimeDescriptionLabel.Size = new Size(179, 24);
            crimeDescriptionLabel.TabIndex = 12;
            crimeDescriptionLabel.Text = "Crime description:";
            // 
            // punishmentBox
            // 
            punishmentBox.Location = new Point(66, 214);
            punishmentBox.Name = "punishmentBox";
            punishmentBox.Size = new Size(488, 23);
            punishmentBox.TabIndex = 11;
            punishmentBox.KeyPress += punishmentBox_KeyPress;
            // 
            // crimeDescBox
            // 
            crimeDescBox.Location = new Point(66, 131);
            crimeDescBox.Name = "crimeDescBox";
            crimeDescBox.Size = new Size(488, 23);
            crimeDescBox.TabIndex = 10;
            crimeDescBox.KeyPress += crimeDescBox_KeyPress;
            // 
            // survivorIDLabel
            // 
            survivorIDLabel.AutoSize = true;
            survivorIDLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            survivorIDLabel.Location = new Point(66, 39);
            survivorIDLabel.Name = "survivorIDLabel";
            survivorIDLabel.Size = new Size(127, 24);
            survivorIDLabel.TabIndex = 14;
            survivorIDLabel.Text = "Survivor ID: ";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(126, 294);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(119, 51);
            addBtn.TabIndex = 15;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(374, 294);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(121, 59);
            cancelBtn.TabIndex = 16;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // AddWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 394);
            Controls.Add(cancelBtn);
            Controls.Add(addBtn);
            Controls.Add(survivorIDLabel);
            Controls.Add(punishmentLabel);
            Controls.Add(crimeDescriptionLabel);
            Controls.Add(punishmentBox);
            Controls.Add(crimeDescBox);
            Name = "AddWindow";
            Text = "Add Crime";
            KeyDown += AddWindow_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label punishmentLabel;
        private Label crimeDescriptionLabel;
        private TextBox punishmentBox;
        private TextBox crimeDescBox;
        private Label survivorIDLabel;
        private Button addBtn;
        private Button cancelBtn;
    }
}