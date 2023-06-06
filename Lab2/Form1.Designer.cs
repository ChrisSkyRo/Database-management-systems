namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            childView = new DataGridView();
            ConnectDB = new Button();
            AddButton = new Button();
            parentView = new DataGridView();
            ParentLabel = new Label();
            ChildLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)childView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)parentView).BeginInit();
            SuspendLayout();
            // 
            // childView
            // 
            childView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            childView.Location = new Point(545, 56);
            childView.Name = "childView";
            childView.RowTemplate.Height = 25;
            childView.Size = new Size(460, 368);
            childView.TabIndex = 1;
            childView.CellClick += childView_CellClick;
            childView.KeyDown += parentView_KeyDown;
            // 
            // ConnectDB
            // 
            ConnectDB.Location = new Point(146, 459);
            ConnectDB.Name = "ConnectDB";
            ConnectDB.Size = new Size(157, 39);
            ConnectDB.TabIndex = 2;
            ConnectDB.Text = "Connect to Database";
            ConnectDB.UseVisualStyleBackColor = true;
            ConnectDB.Click += ConnectDB_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(743, 462);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(98, 36);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // parentView
            // 
            parentView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parentView.Location = new Point(32, 56);
            parentView.Name = "parentView";
            parentView.RowTemplate.Height = 25;
            parentView.Size = new Size(432, 368);
            parentView.TabIndex = 0;
            parentView.CellClick += parentView_CellClick;
            parentView.CellEnter += parentView_CellEnter;
            parentView.KeyDown += parentView_KeyDown;
            // 
            // ParentLabel
            // 
            ParentLabel.AutoSize = true;
            ParentLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ParentLabel.Location = new Point(157, 20);
            ParentLabel.Name = "ParentLabel";
            ParentLabel.Size = new Size(129, 24);
            ParentLabel.TabIndex = 4;
            ParentLabel.Text = "Parent Label";
            // 
            // ChildLabel
            // 
            ChildLabel.AutoSize = true;
            ChildLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ChildLabel.Location = new Point(725, 20);
            ChildLabel.Name = "ChildLabel";
            ChildLabel.Size = new Size(113, 24);
            ChildLabel.TabIndex = 5;
            ChildLabel.Text = "Child Label";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 543);
            Controls.Add(ChildLabel);
            Controls.Add(ParentLabel);
            Controls.Add(AddButton);
            Controls.Add(ConnectDB);
            Controls.Add(childView);
            Controls.Add(parentView);
            Name = "Form1";
            Text = "LawEnforcer V0.47";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)childView).EndInit();
            ((System.ComponentModel.ISupportInitialize)parentView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView childView;
        private Button ConnectDB;
        private Button AddButton;
        private DataGridView parentView;
        private Label ParentLabel;
        private Label ChildLabel;
    }
}