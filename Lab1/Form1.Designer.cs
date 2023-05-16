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
            survivorsView = new DataGridView();
            crimesView = new DataGridView();
            ConnectDB = new Button();
            AddButton = new Button();
            ParentLabel = new Label();
            ChildLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)survivorsView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crimesView).BeginInit();
            SuspendLayout();
            // 
            // survivorsView
            // 
            survivorsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            survivorsView.Location = new Point(32, 56);
            survivorsView.Name = "survivorsView";
            survivorsView.RowTemplate.Height = 25;
            survivorsView.Size = new Size(432, 368);
            survivorsView.TabIndex = 0;
            survivorsView.CellClick += survivorsView_CellClick;
            survivorsView.CellEnter += survivorsView_CellEnter;
            survivorsView.KeyDown += survivorsView_KeyDown;
            // 
            // crimesView
            // 
            crimesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            crimesView.Location = new Point(545, 56);
            crimesView.Name = "crimesView";
            crimesView.RowTemplate.Height = 25;
            crimesView.Size = new Size(460, 368);
            crimesView.TabIndex = 1;
            crimesView.CellClick += crimesView_CellClick;
            crimesView.KeyDown += survivorsView_KeyDown;
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
            AddButton.Text = "Add Crime";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // ParentLabel
            // 
            ParentLabel.AutoSize = true;
            ParentLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ParentLabel.Location = new Point(174, 20);
            ParentLabel.Name = "ParentLabel";
            ParentLabel.Size = new Size(99, 24);
            ParentLabel.TabIndex = 5;
            ParentLabel.Text = "Survivors";
            // 
            // ChildLabel
            // 
            ChildLabel.AutoSize = true;
            ChildLabel.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ChildLabel.Location = new Point(725, 20);
            ChildLabel.Name = "ChildLabel";
            ChildLabel.Size = new Size(76, 24);
            ChildLabel.TabIndex = 6;
            ChildLabel.Text = "Crimes";
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
            Controls.Add(crimesView);
            Controls.Add(survivorsView);
            Name = "Form1";
            Text = "LawEnforcer V0.28";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)survivorsView).EndInit();
            ((System.ComponentModel.ISupportInitialize)crimesView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView survivorsView;
        private DataGridView crimesView;
        private Button ConnectDB;
        private Button AddButton;
        private Label ParentLabel;
        private Label ChildLabel;
    }
}