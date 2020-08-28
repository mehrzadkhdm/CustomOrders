namespace CustomOrders
{
    partial class getOrders
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.radioButtonOrderNumber = new System.Windows.Forms.RadioButton();
            this.radioButtonDateRange = new System.Windows.Forms.RadioButton();
            this.radioButtonUnshipped = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textBoxOrderNumber);
            this.groupBox1.Controls.Add(this.radioButtonOrderNumber);
            this.groupBox1.Controls.Add(this.radioButtonDateRange);
            this.groupBox1.Controls.Add(this.radioButtonUnshipped);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get orders";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(438, 102);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(272, 66);
            this.dateTimePicker2.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 66);
            this.dateTimePicker1.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSearch.Location = new System.Drawing.Point(519, 101);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxOrderNumber
            // 
            this.textBoxOrderNumber.Enabled = false;
            this.textBoxOrderNumber.Location = new System.Drawing.Point(103, 104);
            this.textBoxOrderNumber.Name = "textBoxOrderNumber";
            this.textBoxOrderNumber.Size = new System.Drawing.Size(267, 20);
            this.textBoxOrderNumber.TabIndex = 3;
            this.textBoxOrderNumber.Tag = "PrintingTestOrder001--";
            this.textBoxOrderNumber.Text = "113-7186279-3991433";
            // 
            // radioButtonOrderNumber
            // 
            this.radioButtonOrderNumber.AutoSize = true;
            this.radioButtonOrderNumber.Location = new System.Drawing.Point(7, 104);
            this.radioButtonOrderNumber.Name = "radioButtonOrderNumber";
            this.radioButtonOrderNumber.Size = new System.Drawing.Size(89, 17);
            this.radioButtonOrderNumber.TabIndex = 2;
            this.radioButtonOrderNumber.Text = "Order number";
            this.radioButtonOrderNumber.UseVisualStyleBackColor = true;
            this.radioButtonOrderNumber.CheckedChanged += new System.EventHandler(this.radioButtonOrderNumber_CheckedChanged);
            // 
            // radioButtonDateRange
            // 
            this.radioButtonDateRange.AutoSize = true;
            this.radioButtonDateRange.Location = new System.Drawing.Point(7, 66);
            this.radioButtonDateRange.Name = "radioButtonDateRange";
            this.radioButtonDateRange.Size = new System.Drawing.Size(78, 17);
            this.radioButtonDateRange.TabIndex = 1;
            this.radioButtonDateRange.Text = "Date range";
            this.radioButtonDateRange.UseVisualStyleBackColor = true;
            this.radioButtonDateRange.CheckedChanged += new System.EventHandler(this.radioButtonDateRange_CheckedChanged);
            // 
            // radioButtonUnshipped
            // 
            this.radioButtonUnshipped.AutoSize = true;
            this.radioButtonUnshipped.Checked = true;
            this.radioButtonUnshipped.Location = new System.Drawing.Point(7, 31);
            this.radioButtonUnshipped.Name = "radioButtonUnshipped";
            this.radioButtonUnshipped.Size = new System.Drawing.Size(108, 17);
            this.radioButtonUnshipped.TabIndex = 0;
            this.radioButtonUnshipped.TabStop = true;
            this.radioButtonUnshipped.Text = "Unshipped orders";
            this.radioButtonUnshipped.UseVisualStyleBackColor = true;
            this.radioButtonUnshipped.CheckedChanged += new System.EventHandler(this.radioButtonUnshipped_CheckedChanged);
            // 
            // getOrders
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(624, 172);
            this.Controls.Add(this.groupBox1);
            this.Name = "getOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Get Orders";
            this.Load += new System.EventHandler(this.getOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxOrderNumber;
        private System.Windows.Forms.RadioButton radioButtonOrderNumber;
        private System.Windows.Forms.RadioButton radioButtonDateRange;
        private System.Windows.Forms.RadioButton radioButtonUnshipped;
    }
}