
namespace PowerPoint
{
    partial class Form1
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
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._button1 = new System.Windows.Forms.Button();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this._groupBox1.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToDeleteRows = false;
            this._dataGridView1.AllowUserToResizeColumns = false;
            this._dataGridView1.AllowUserToResizeRows = false;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete});
            this._dataGridView1.Location = new System.Drawing.Point(4, 77);
            this._dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 24;
            this._dataGridView1.Size = new System.Drawing.Size(277, 550);
            this._dataGridView1.TabIndex = 0;
            this._dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellContentClick);
            // 
            // _groupBox1
            // 
            this._groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._groupBox1.Controls.Add(this._comboBox1);
            this._groupBox1.Controls.Add(this._button1);
            this._groupBox1.Controls.Add(this._dataGridView1);
            this._groupBox1.Location = new System.Drawing.Point(660, 26);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this._groupBox1.Size = new System.Drawing.Size(286, 546);
            this._groupBox1.TabIndex = 1;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "_groupBox1";
            // 
            // _comboBox1
            // 
            this._comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Location = new System.Drawing.Point(120, 31);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(121, 21);
            this._comboBox1.TabIndex = 2;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(17, 31);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(75, 23);
            this._button1.TabIndex = 1;
            this._button1.Text = "Add";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem1});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(946, 24);
            this._menuStrip1.TabIndex = 2;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _toolStripMenuItem1
            // 
            this._toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem1.Name = "_toolStripMenuItem1";
            this._toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this._toolStripMenuItem1.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this._aboutToolStripMenuItem.Text = "About";
            // 
            // _groupBox2
            // 
            this._groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this._groupBox2.Location = new System.Drawing.Point(0, 26);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Size = new System.Drawing.Size(200, 522);
            this._groupBox2.TabIndex = 3;
            this._groupBox2.TabStop = false;
            this._groupBox2.Text = "_groupBox2";
            // 
            // _delete
            // 
            this._delete.DataPropertyName = "Delete";
            this._delete.HeaderText = "Delete";
            this._delete.MinimumWidth = 6;
            this._delete.Name = "_delete";
            this._delete.ReadOnly = true;
            this._delete.Text = "Delete";
            this._delete.UseColumnTextForButtonValue = true;
            this._delete.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this._groupBox2);
            this.Controls.Add(this._groupBox1);
            this.Controls.Add(this._menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
    }
}

