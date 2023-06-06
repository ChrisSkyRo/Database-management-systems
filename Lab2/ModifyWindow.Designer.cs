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
            updateBtn = new Button();
            deleteBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
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
            Name = "ModifyWindow";
            Text = "Modify Crime";
            KeyDown += ModifyWindow_KeyDown;
            ResumeLayout(false);
        }

        #endregion
        private Button updateBtn;
        private Button deleteBtn;
        private Button cancelBtn;
    }
}