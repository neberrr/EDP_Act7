namespace Motorcycle_Rental
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            rentalStatusToolStripMenuItem = new ToolStripMenuItem();
            rentalHistoryToolStripMenuItem = new ToolStripMenuItem();
            paymentHistoryToolStripMenuItem = new ToolStripMenuItem();
            availableMotorcyclesToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label13 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, rentalStatusToolStripMenuItem, accountToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1161, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(64, 24);
            homeToolStripMenuItem.Text = "Home";
            // 
            // rentalStatusToolStripMenuItem
            // 
            rentalStatusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rentalHistoryToolStripMenuItem, paymentHistoryToolStripMenuItem, availableMotorcyclesToolStripMenuItem });
            rentalStatusToolStripMenuItem.Name = "rentalStatusToolStripMenuItem";
            rentalStatusToolStripMenuItem.Size = new Size(109, 24);
            rentalStatusToolStripMenuItem.Text = "Rental Status";
            rentalStatusToolStripMenuItem.Click += rentalStatusToolStripMenuItem_Click;
            // 
            // rentalHistoryToolStripMenuItem
            // 
            rentalHistoryToolStripMenuItem.Name = "rentalHistoryToolStripMenuItem";
            rentalHistoryToolStripMenuItem.Size = new Size(238, 26);
            rentalHistoryToolStripMenuItem.Text = "Rental History";
            rentalHistoryToolStripMenuItem.Click += rentalHistoryToolStripMenuItem_Click;
            // 
            // paymentHistoryToolStripMenuItem
            // 
            paymentHistoryToolStripMenuItem.Name = "paymentHistoryToolStripMenuItem";
            paymentHistoryToolStripMenuItem.Size = new Size(238, 26);
            paymentHistoryToolStripMenuItem.Text = "Payment History";
            paymentHistoryToolStripMenuItem.Click += paymentHistoryToolStripMenuItem_Click;
            // 
            // availableMotorcyclesToolStripMenuItem
            // 
            availableMotorcyclesToolStripMenuItem.Name = "availableMotorcyclesToolStripMenuItem";
            availableMotorcyclesToolStripMenuItem.Size = new Size(238, 26);
            availableMotorcyclesToolStripMenuItem.Text = "Available Motorcycles";
            availableMotorcyclesToolStripMenuItem.Click += availableMotorcyclesToolStripMenuItem_Click;
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(77, 24);
            accountToolStripMenuItem.Text = "Account";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(268, 37);
            label1.TabIndex = 1;
            label1.Text = "Rental History";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(248, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(665, 396);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(1003, 552);
            button1.Name = "button1";
            button1.Size = new Size(136, 29);
            button1.TabIndex = 4;
            button1.Text = "Generate Data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveBorder;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(835, 552);
            button2.Name = "button2";
            button2.Size = new Size(130, 29);
            button2.TabIndex = 5;
            button2.Text = "Select Template";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.ForeColor = SystemColors.ButtonFace;
            label13.Location = new Point(200, 556);
            label13.Name = "label13";
            label13.Size = new Size(77, 20);
            label13.TabIndex = 6;
            label13.Text = "*file name";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1161, 593);
            Controls.Add(label13);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form5";
            Text = "Form5";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem rentalStatusToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Label label13;
        private ToolStripMenuItem rentalHistoryToolStripMenuItem;
        private ToolStripMenuItem paymentHistoryToolStripMenuItem;
        private ToolStripMenuItem availableMotorcyclesToolStripMenuItem;
    }
}