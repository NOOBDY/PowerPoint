
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._addButton = new System.Windows.Forms.Button();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._preview = new System.Windows.Forms.Button();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this._groupBox3 = new System.Windows.Forms.GroupBox();
            this._canvas = new PowerPoint.Canvas();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this._groupBox1.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            this._groupBox2.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            this._groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToDeleteRows = false;
            this._dataGridView1.AllowUserToResizeColumns = false;
            this._dataGridView1.AllowUserToResizeRows = false;
            this._dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete});
            this._dataGridView1.Location = new System.Drawing.Point(17, 59);
            this._dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 24;
            this._dataGridView1.Size = new System.Drawing.Size(118, 447);
            this._dataGridView1.TabIndex = 0;
            this._dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridView1CellContent);
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
            // _groupBox1
            // 
            this._groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._groupBox1.Controls.Add(this._comboBox1);
            this._groupBox1.Controls.Add(this._addButton);
            this._groupBox1.Controls.Add(this._dataGridView1);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this._groupBox1.Location = new System.Drawing.Point(780, 16);
            this._groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this._groupBox1.Size = new System.Drawing.Size(139, 462);
            this._groupBox1.TabIndex = 1;
            this._groupBox1.TabStop = false;
            // 
            // _comboBox1
            // 
            this._comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Location = new System.Drawing.Point(120, 31);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(14, 21);
            this._comboBox1.TabIndex = 2;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(17, 31);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(97, 23);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.Button1Click);
            // 
            // _menuStrip1
            // 
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem1});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
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
            this._groupBox2.Controls.Add(this._preview);
            this._groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this._groupBox2.Location = new System.Drawing.Point(3, 16);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Size = new System.Drawing.Size(130, 462);
            this._groupBox2.TabIndex = 3;
            this._groupBox2.TabStop = false;
            // 
            // _preview
            // 
            this._preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._preview.Location = new System.Drawing.Point(5, 11);
            this._preview.Margin = new System.Windows.Forms.Padding(2);
            this._preview.Name = "_preview";
            this._preview.Size = new System.Drawing.Size(120, 137);
            this._preview.TabIndex = 0;
            this._preview.UseVisualStyleBackColor = true;
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton1,
            this._toolStripButton2,
            this._toolStripButton3,
            this._toolStripButton4,
            this._toolStripButton5,
            this._toolStripButton6});
            this._toolStrip1.Location = new System.Drawing.Point(0, 24);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(946, 27);
            this._toolStrip1.TabIndex = 4;
            this._toolStrip1.Text = "_toolStrip1";
            // 
            // _toolStripButton1
            // 
            this._toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton1.Image")));
            this._toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton1.Name = "_toolStripButton1";
            this._toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton1.Text = "_toolStripButton1";
            // 
            // _toolStripButton2
            // 
            this._toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton2.Image")));
            this._toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton2.Name = "_toolStripButton2";
            this._toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton2.Text = "_toolStripButton2";
            // 
            // _toolStripButton3
            // 
            this._toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton3.Image")));
            this._toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton3.Name = "_toolStripButton3";
            this._toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton3.Text = "_toolStripButton3";
            // 
            // _toolStripButton4
            // 
            this._toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton4.Image")));
            this._toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton4.Name = "_toolStripButton4";
            this._toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton4.Text = "_toolStripButton4";
            // 
            // _toolStripButton5
            // 
            this._toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton5.Image")));
            this._toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton5.Name = "_toolStripButton5";
            this._toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton5.Text = "_toolStripButton5";
            this._toolStripButton5.Click += new System.EventHandler(this.ClickUndoButton);
            // 
            // _toolStripButton6
            // 
            this._toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton6.Image")));
            this._toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton6.Name = "_toolStripButton6";
            this._toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this._toolStripButton6.Text = "_toolStripButton6";
            this._toolStripButton6.Click += new System.EventHandler(this.ClickRedoButton);
            // 
            // _groupBox3
            // 
            this._groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBox3.Controls.Add(this.groupBox1);
            this._groupBox3.Controls.Add(this.splitter2);
            this._groupBox3.Controls.Add(this.splitter1);
            this._groupBox3.Controls.Add(this._groupBox2);
            this._groupBox3.Controls.Add(this._groupBox1);
            this._groupBox3.Location = new System.Drawing.Point(12, 54);
            this._groupBox3.Name = "_groupBox3";
            this._groupBox3.Size = new System.Drawing.Size(922, 481);
            this._groupBox3.TabIndex = 6;
            this._groupBox3.TabStop = false;
            this._groupBox3.Text = "groupBox1";
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.AutoSize = true;
            this._canvas.BackColor = System.Drawing.SystemColors.Info;
            this._canvas.Location = new System.Drawing.Point(6, 19);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(604, 153);
            this._canvas.TabIndex = 5;
            this._canvas.SizeChanged += new System.EventHandler(this.SetAspectRatio);
            this._canvas.Resize += new System.EventHandler(this._canvas_Resize);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(758, 16);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(22, 462);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlText;
            this.splitter1.Location = new System.Drawing.Point(133, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(9, 462);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._canvas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(142, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 462);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this._groupBox3);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this._groupBox1.ResumeLayout(false);
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._groupBox2.ResumeLayout(false);
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private System.Windows.Forms.ToolStripButton _toolStripButton1;
        private System.Windows.Forms.ToolStripButton _toolStripButton2;
        private System.Windows.Forms.ToolStripButton _toolStripButton3;
        private Canvas _canvas;
        private System.Windows.Forms.ToolStripButton _toolStripButton4;
        private System.Windows.Forms.Button _preview;
        private System.Windows.Forms.ToolStripButton _toolStripButton5;
        private System.Windows.Forms.ToolStripButton _toolStripButton6;
        private System.Windows.Forms.GroupBox _groupBox3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

