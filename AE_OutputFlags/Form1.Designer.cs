
namespace AE_OutputFlags
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.clstOutFlags1 = new System.Windows.Forms.CheckedListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tbCom1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.num1 = new System.Windows.Forms.NumericUpDown();
			this.tbCom2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.num2 = new System.Windows.Forms.NumericUpDown();
			this.clstOutFlags2 = new System.Windows.Forms.CheckedListBox();
			this.tbDes1 = new System.Windows.Forms.TextBox();
			this.tbDes2 = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnImport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExportJson = new System.Windows.Forms.ToolStripButton();
			this.btnImportJson = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnVersion = new System.Windows.Forms.ToolStripButton();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.aE_Effect1 = new AE_OutputFlags.AE_Effect();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num2)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "h";
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// clstOutFlags1
			// 
			this.clstOutFlags1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.clstOutFlags1.FormattingEnabled = true;
			this.clstOutFlags1.Location = new System.Drawing.Point(3, 38);
			this.clstOutFlags1.Name = "clstOutFlags1";
			this.clstOutFlags1.Size = new System.Drawing.Size(343, 202);
			this.clstOutFlags1.TabIndex = 1;
			this.clstOutFlags1.Tag = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tbCom1);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.num1);
			this.splitContainer1.Panel1.Controls.Add(this.clstOutFlags1);
			this.splitContainer1.Panel1MinSize = 50;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tbCom2);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.num2);
			this.splitContainer1.Panel2.Controls.Add(this.clstOutFlags2);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(715, 298);
			this.splitContainer1.SplitterDistance = 349;
			this.splitContainer1.SplitterIncrement = 6;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 2;
			// 
			// tbCom1
			// 
			this.tbCom1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCom1.Location = new System.Drawing.Point(6, 272);
			this.tbCom1.Name = "tbCom1";
			this.tbCom1.ReadOnly = true;
			this.tbCom1.Size = new System.Drawing.Size(340, 23);
			this.tbCom1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "output flags";
			// 
			// num1
			// 
			this.num1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.num1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.num1.Location = new System.Drawing.Point(148, 3);
			this.num1.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.num1.Name = "num1";
			this.num1.Size = new System.Drawing.Size(198, 29);
			this.num1.TabIndex = 2;
			this.num1.Tag = 1;
			this.num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbCom2
			// 
			this.tbCom2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCom2.Location = new System.Drawing.Point(3, 272);
			this.tbCom2.Name = "tbCom2";
			this.tbCom2.ReadOnly = true;
			this.tbCom2.Size = new System.Drawing.Size(346, 23);
			this.tbCom2.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "output flags2";
			// 
			// num2
			// 
			this.num2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.num2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.num2.Location = new System.Drawing.Point(159, 3);
			this.num2.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.num2.Name = "num2";
			this.num2.Size = new System.Drawing.Size(190, 29);
			this.num2.TabIndex = 3;
			this.num2.Tag = 1;
			this.num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// clstOutFlags2
			// 
			this.clstOutFlags2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.clstOutFlags2.FormattingEnabled = true;
			this.clstOutFlags2.Location = new System.Drawing.Point(3, 38);
			this.clstOutFlags2.Name = "clstOutFlags2";
			this.clstOutFlags2.Size = new System.Drawing.Size(346, 202);
			this.clstOutFlags2.TabIndex = 0;
			this.clstOutFlags2.Tag = 2;
			// 
			// tbDes1
			// 
			this.tbDes1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbDes1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbDes1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbDes1.Location = new System.Drawing.Point(0, 0);
			this.tbDes1.Multiline = true;
			this.tbDes1.Name = "tbDes1";
			this.tbDes1.ReadOnly = true;
			this.tbDes1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDes1.Size = new System.Drawing.Size(715, 195);
			this.tbDes1.TabIndex = 3;
			// 
			// tbDes2
			// 
			this.tbDes2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbDes2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbDes2.Location = new System.Drawing.Point(0, 0);
			this.tbDes2.Multiline = true;
			this.tbDes2.Name = "tbDes2";
			this.tbDes2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDes2.Size = new System.Drawing.Size(715, 163);
			this.tbDes2.TabIndex = 4;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.toolStripSeparator1,
            this.btnExportJson,
            this.btnImportJson,
            this.toolStripSeparator2,
            this.btnVersion});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(715, 28);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnImport
			// 
			this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnImport.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
			this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(153, 25);
			this.btnImport.Text = "Import_AfterEffect.h";
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
			// 
			// btnExportJson
			// 
			this.btnExportJson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnExportJson.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnExportJson.Image = ((System.Drawing.Image)(resources.GetObject("btnExportJson.Image")));
			this.btnExportJson.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExportJson.Name = "btnExportJson";
			this.btnExportJson.Size = new System.Drawing.Size(96, 25);
			this.btnExportJson.Text = "Export_Json";
			this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
			// 
			// btnImportJson
			// 
			this.btnImportJson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnImportJson.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnImportJson.Image = ((System.Drawing.Image)(resources.GetObject("btnImportJson.Image")));
			this.btnImportJson.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImportJson.Name = "btnImportJson";
			this.btnImportJson.Size = new System.Drawing.Size(99, 25);
			this.btnImportJson.Text = "Import_Json";
			this.btnImportJson.Click += new System.EventHandler(this.btnImportJson_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
			// 
			// btnVersion
			// 
			this.btnVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnVersion.Image = ((System.Drawing.Image)(resources.GetObject("btnVersion.Image")));
			this.btnVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnVersion.Name = "btnVersion";
			this.btnVersion.Size = new System.Drawing.Size(117, 25);
			this.btnVersion.Text = "show Version Dialog";
			this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 28);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer2.Size = new System.Drawing.Size(715, 668);
			this.splitContainer2.SplitterDistance = 298;
			this.splitContainer2.SplitterIncrement = 6;
			this.splitContainer2.SplitterWidth = 6;
			this.splitContainer2.TabIndex = 6;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.tbDes1);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.tbDes2);
			this.splitContainer3.Size = new System.Drawing.Size(715, 364);
			this.splitContainer3.SplitterDistance = 195;
			this.splitContainer3.SplitterIncrement = 6;
			this.splitContainer3.SplitterWidth = 6;
			this.splitContainer3.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(186, 242);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(8, 8);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(0, 0);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(0, -20);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// aE_Effect1
			// 
			this.aE_Effect1.ComBox1 = this.tbCom1;
			this.aE_Effect1.ComBox2 = this.tbCom2;
			this.aE_Effect1.DescriptionBox = this.tbDes1;
			this.aE_Effect1.DescriptionBoxJ = this.tbDes2;
			this.aE_Effect1.ListBox1 = this.clstOutFlags1;
			this.aE_Effect1.ListBox2 = this.clstOutFlags2;
			this.aE_Effect1.Num1 = this.num1;
			this.aE_Effect1.Num2 = this.num2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 696);
			this.Controls.Add(this.splitContainer2);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "AE_OutputFlags";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num2)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.CheckedListBox clstOutFlags1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.CheckedListBox clstOutFlags2;
		private System.Windows.Forms.TextBox tbDes1;
		private System.Windows.Forms.TextBox tbDes2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnImport;
		private System.Windows.Forms.ToolStripButton btnExportJson;
		private System.Windows.Forms.ToolStripButton btnImportJson;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown num1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown num2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private AE_Effect aE_Effect1;
		private System.Windows.Forms.TextBox tbCom1;
		private System.Windows.Forms.TextBox tbCom2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnVersion;
	}
}

