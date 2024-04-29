namespace Motorcycle_Rental
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label13 = new Label();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            historyToolStripMenuItem = new ToolStripMenuItem();
            rentalHistoryToolStripMenuItem = new ToolStripMenuItem();
            paymentHistoryToolStripMenuItem = new ToolStripMenuItem();
            availableMotorcyclesToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(234, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(706, 404);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 53);
            label1.Name = "label1";
            label1.Size = new Size(298, 37);
            label1.TabIndex = 1;
            label1.Text = "Payment History";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveBorder;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(1068, 563);
            button1.Name = "button1";
            button1.Size = new Size(121, 28);
            button1.TabIndex = 2;
            button1.Text = "Generate Data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveBorder;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(910, 562);
            button2.Name = "button2";
            button2.Size = new Size(127, 29);
            button2.TabIndex = 3;
            button2.Text = "Select Template";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.ForeColor = SystemColors.ButtonFace;
            label13.Location = new Point(302, 567);
            label13.Name = "label13";
            label13.Size = new Size(77, 20);
            label13.TabIndex = 4;
            label13.Text = "*file name";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, historyToolStripMenuItem, accountToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1201, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(64, 24);
            homeToolStripMenuItem.Text = "Home";
            // 
            // historyToolStripMenuItem
            // 
            historyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rentalHistoryToolStripMenuItem, paymentHistoryToolStripMenuItem, availableMotorcyclesToolStripMenuItem });
            historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            historyToolStripMenuItem.Size = new Size(109, 24);
            historyToolStripMenuItem.Text = "Rental Status";
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
            // Form10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1201, 603);
            Controls.Add(label13);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form10";
            Text = "Form10";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label13;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem rentalHistoryToolStripMenuItem;
        private ToolStripMenuItem paymentHistoryToolStripMenuItem;
        private ToolStripMenuItem availableMotorcyclesToolStripMenuItem;
    }
}