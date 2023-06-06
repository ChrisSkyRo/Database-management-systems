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
            addBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
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
            Name = "AddWindow";
            Text = "Add Crime";
            KeyDown += AddWindow_KeyDown;
            ResumeLayout(false);
        }

        #endregion
        private Button addBtn;
        private Button cancelBtn;
    }
}