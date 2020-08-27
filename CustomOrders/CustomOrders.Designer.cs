namespace CustomOrders
{
    partial class CustomOrders
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipStattionOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getOrdersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChecBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAmazon = new System.Windows.Forms.DataGridViewLinkColumn();
            this.SKUColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shipStattionOrdersToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOrderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openOrderToolStripMenuItem
            // 
            this.openOrderToolStripMenuItem.Name = "openOrderToolStripMenuItem";
            this.openOrderToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openOrderToolStripMenuItem.Text = "Open order";
            this.openOrderToolStripMenuItem.Click += new System.EventHandler(this.openOrderToolStripMenuItem_Click);
            // 
            // shipStattionOrdersToolStripMenuItem
            // 
            this.shipStattionOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getOrdersStripMenuItem});
            this.shipStattionOrdersToolStripMenuItem.Name = "shipStattionOrdersToolStripMenuItem";
            this.shipStattionOrdersToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.shipStattionOrdersToolStripMenuItem.Text = "ShipStation Orders";
            this.shipStattionOrdersToolStripMenuItem.Click += new System.EventHandler(this.shipStattionOrdersToolStripMenuItem_Click);
            // 
            // getOrdersStripMenuItem
            // 
            this.getOrdersStripMenuItem.Name = "getOrdersStripMenuItem";
            this.getOrdersStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.getOrdersStripMenuItem.Text = "Ger Orders";
            this.getOrdersStripMenuItem.Click += new System.EventHandler(this.getOrdersStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configFileToolStripMenuItem,
            this.outputFolderToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // configFileToolStripMenuItem
            // 
            this.configFileToolStripMenuItem.Name = "configFileToolStripMenuItem";
            this.configFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configFileToolStripMenuItem.Text = "Config file";
            this.configFileToolStripMenuItem.Click += new System.EventHandler(this.configFileToolStripMenuItem_Click);
            // 
            // outputFolderToolStripMenuItem
            // 
            this.outputFolderToolStripMenuItem.Name = "outputFolderToolStripMenuItem";
            this.outputFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outputFolderToolStripMenuItem.Text = "Output Folder";
            this.outputFolderToolStripMenuItem.Click += new System.EventHandler(this.outputFolderToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoColumn,
            this.ColumnChecBox,
            this.ColumnAmazon,
            this.SKUColumn,
            this.Column2,
            this.ColumnProgress,
            this.orderIDColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 74);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1002, 472);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // NoColumn
            // 
            this.NoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NoColumn.HeaderText = "No.";
            this.NoColumn.Name = "NoColumn";
            this.NoColumn.ReadOnly = true;
            this.NoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoColumn.Width = 30;
            // 
            // ColumnChecBox
            // 
            this.ColumnChecBox.HeaderText = "Process Order";
            this.ColumnChecBox.Name = "ColumnChecBox";
            this.ColumnChecBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnChecBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnAmazon
            // 
            this.ColumnAmazon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAmazon.HeaderText = "Amazon Order Id";
            this.ColumnAmazon.Name = "ColumnAmazon";
            this.ColumnAmazon.ReadOnly = true;
            this.ColumnAmazon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAmazon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAmazon.TrackVisitedState = false;
            this.ColumnAmazon.Width = 120;
            // 
            // SKUColumn
            // 
            this.SKUColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SKUColumn.HeaderText = "SKU";
            this.SKUColumn.MinimumWidth = 100;
            this.SKUColumn.Name = "SKUColumn";
            this.SKUColumn.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Order Status";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColumnProgress
            // 
            this.ColumnProgress.HeaderText = "Progress";
            this.ColumnProgress.Name = "ColumnProgress";
            this.ColumnProgress.ReadOnly = true;
            // 
            // orderIDColumn
            // 
            this.orderIDColumn.HeaderText = "orderId";
            this.orderIDColumn.Name = "orderIDColumn";
            this.orderIDColumn.ReadOnly = true;
            this.orderIDColumn.Visible = false;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(871, 45);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(143, 23);
            this.buttonProcess.TabIndex = 3;
            this.buttonProcess.Text = "Process selected orders";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Select All/Unselect All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CustomOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 558);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CustomOrders";
            this.Text = "Custom Order";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomOrders_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipStattionOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getOrdersStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem outputFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnChecBox;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnAmazon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKUColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDColumn;
    }
}

