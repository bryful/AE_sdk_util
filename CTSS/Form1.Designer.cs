
namespace CTSS
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
			this.tbExe = new System.Windows.Forms.TextBox();
			this.btnSelectExe = new System.Windows.Forms.Button();
			this.btnPdb = new System.Windows.Forms.Button();
			this.tbPdb = new System.Windows.Forms.TextBox();
			this.gbOptions = new System.Windows.Forms.GroupBox();
			this.btnAna = new System.Windows.Forms.Button();
			this.rb3 = new System.Windows.Forms.RadioButton();
			this.tbAna = new System.Windows.Forms.TextBox();
			this.rb2 = new System.Windows.Forms.RadioButton();
			this.rb1 = new System.Windows.Forms.RadioButton();
			this.rb0 = new System.Windows.Forms.RadioButton();
			this.btnExec = new System.Windows.Forms.Button();
			this.btnBatch = new System.Windows.Forms.Button();
			this.tbCmd = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SelectExeMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.SelectPdpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.SelectAnalysysMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctsScomp1 = new CTSS.CTSScomp();
			this.gbOptions.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbExe
			// 
			this.tbExe.AllowDrop = true;
			this.tbExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbExe.Location = new System.Drawing.Point(7, 71);
			this.tbExe.Name = "tbExe";
			this.tbExe.Size = new System.Drawing.Size(789, 23);
			this.tbExe.TabIndex = 0;
			this.tbExe.TextChanged += new System.EventHandler(this.tbExe_TextChanged);
			this.tbExe.DragDrop += new System.Windows.Forms.DragEventHandler(this.exe_DragDrop);
			this.tbExe.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// btnSelectExe
			// 
			this.btnSelectExe.AllowDrop = true;
			this.btnSelectExe.Location = new System.Drawing.Point(8, 42);
			this.btnSelectExe.Name = "btnSelectExe";
			this.btnSelectExe.Size = new System.Drawing.Size(268, 23);
			this.btnSelectExe.TabIndex = 1;
			this.btnSelectExe.Text = "CheckThreadSafeSymbols.exe";
			this.btnSelectExe.UseVisualStyleBackColor = true;
			this.btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);
			this.btnSelectExe.DragDrop += new System.Windows.Forms.DragEventHandler(this.exe_DragDrop);
			this.btnSelectExe.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// btnPdb
			// 
			this.btnPdb.AllowDrop = true;
			this.btnPdb.Location = new System.Drawing.Point(9, 105);
			this.btnPdb.Name = "btnPdb";
			this.btnPdb.Size = new System.Drawing.Size(267, 23);
			this.btnPdb.TabIndex = 3;
			this.btnPdb.Text = "absolute path to .pdb";
			this.btnPdb.UseVisualStyleBackColor = true;
			this.btnPdb.Click += new System.EventHandler(this.btnPdb_Click);
			this.btnPdb.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pdb_DragDrop);
			this.btnPdb.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// tbPdb
			// 
			this.tbPdb.AllowDrop = true;
			this.tbPdb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPdb.Location = new System.Drawing.Point(8, 134);
			this.tbPdb.Name = "tbPdb";
			this.tbPdb.Size = new System.Drawing.Size(788, 23);
			this.tbPdb.TabIndex = 2;
			this.tbPdb.TextChanged += new System.EventHandler(this.tbExe_TextChanged);
			this.tbPdb.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pdb_DragDrop);
			this.tbPdb.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// gbOptions
			// 
			this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbOptions.Controls.Add(this.btnAna);
			this.gbOptions.Controls.Add(this.rb3);
			this.gbOptions.Controls.Add(this.tbAna);
			this.gbOptions.Controls.Add(this.rb2);
			this.gbOptions.Controls.Add(this.rb1);
			this.gbOptions.Controls.Add(this.rb0);
			this.gbOptions.Location = new System.Drawing.Point(9, 160);
			this.gbOptions.Name = "gbOptions";
			this.gbOptions.Size = new System.Drawing.Size(787, 124);
			this.gbOptions.TabIndex = 4;
			this.gbOptions.TabStop = false;
			this.gbOptions.Text = "Options";
			// 
			// btnAna
			// 
			this.btnAna.AllowDrop = true;
			this.btnAna.Enabled = false;
			this.btnAna.Location = new System.Drawing.Point(6, 58);
			this.btnAna.Name = "btnAna";
			this.btnAna.Size = new System.Drawing.Size(386, 23);
			this.btnAna.TabIndex = 6;
			this.btnAna.Text = "absolute path to the [binary or source] you want analyzed";
			this.btnAna.UseVisualStyleBackColor = true;
			this.btnAna.Click += new System.EventHandler(this.btnAna_Click);
			this.btnAna.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnAna_DragDrop);
			this.btnAna.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// rb3
			// 
			this.rb3.AutoSize = true;
			this.rb3.Location = new System.Drawing.Point(204, 33);
			this.rb3.Name = "rb3";
			this.rb3.Size = new System.Drawing.Size(63, 19);
			this.rb3.TabIndex = 3;
			this.rb3.Text = "-objfile";
			this.rb3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.rb3.UseVisualStyleBackColor = true;
			this.rb3.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
			// 
			// tbAna
			// 
			this.tbAna.AllowDrop = true;
			this.tbAna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAna.Enabled = false;
			this.tbAna.Location = new System.Drawing.Point(7, 87);
			this.tbAna.Name = "tbAna";
			this.tbAna.Size = new System.Drawing.Size(760, 23);
			this.tbAna.TabIndex = 5;
			this.tbAna.TextChanged += new System.EventHandler(this.tbExe_TextChanged);
			this.tbAna.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnAna_DragDrop);
			this.tbAna.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ctrl_DragEnter);
			// 
			// rb2
			// 
			this.rb2.AutoSize = true;
			this.rb2.Location = new System.Drawing.Point(135, 33);
			this.rb2.Name = "rb2";
			this.rb2.Size = new System.Drawing.Size(65, 19);
			this.rb2.TabIndex = 2;
			this.rb2.Text = "-source";
			this.rb2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.rb2.UseVisualStyleBackColor = true;
			this.rb2.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
			// 
			// rb1
			// 
			this.rb1.AutoSize = true;
			this.rb1.Checked = true;
			this.rb1.Location = new System.Drawing.Point(92, 33);
			this.rb1.Name = "rb1";
			this.rb1.Size = new System.Drawing.Size(37, 19);
			this.rb1.TabIndex = 1;
			this.rb1.TabStop = true;
			this.rb1.Text = "-g";
			this.rb1.UseVisualStyleBackColor = true;
			this.rb1.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
			// 
			// rb0
			// 
			this.rb0.AutoSize = true;
			this.rb0.Location = new System.Drawing.Point(34, 33);
			this.rb0.Name = "rb0";
			this.rb0.Size = new System.Drawing.Size(39, 19);
			this.rb0.TabIndex = 0;
			this.rb0.Text = "-sf";
			this.rb0.UseVisualStyleBackColor = true;
			this.rb0.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
			// 
			// btnExec
			// 
			this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExec.Location = new System.Drawing.Point(674, 370);
			this.btnExec.Name = "btnExec";
			this.btnExec.Size = new System.Drawing.Size(103, 39);
			this.btnExec.TabIndex = 5;
			this.btnExec.Text = "Exec";
			this.btnExec.UseVisualStyleBackColor = true;
			this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
			// 
			// btnBatch
			// 
			this.btnBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBatch.Location = new System.Drawing.Point(548, 372);
			this.btnBatch.Name = "btnBatch";
			this.btnBatch.Size = new System.Drawing.Size(103, 39);
			this.btnBatch.TabIndex = 6;
			this.btnBatch.Text = "Make Batch";
			this.btnBatch.UseVisualStyleBackColor = true;
			// 
			// tbCmd
			// 
			this.tbCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCmd.Location = new System.Drawing.Point(11, 290);
			this.tbCmd.Multiline = true;
			this.tbCmd.Name = "tbCmd";
			this.tbCmd.Size = new System.Drawing.Size(787, 76);
			this.tbCmd.TabIndex = 7;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(808, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectExeMenu,
            this.SelectPdpMenu,
            this.SelectAnalysysMenu,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// SelectExeMenu
			// 
			this.SelectExeMenu.Name = "SelectExeMenu";
			this.SelectExeMenu.Size = new System.Drawing.Size(263, 22);
			this.SelectExeMenu.Text = "Select CheckThreadSafeSymbols.exe";
			this.SelectExeMenu.Click += new System.EventHandler(this.SelectExeMenu_Click);
			// 
			// SelectPdpMenu
			// 
			this.SelectPdpMenu.Name = "SelectPdpMenu";
			this.SelectPdpMenu.Size = new System.Drawing.Size(263, 22);
			this.SelectPdpMenu.Text = "Select *.pdp";
			this.SelectPdpMenu.Click += new System.EventHandler(this.SelectPdpMenu_Click);
			// 
			// SelectAnalysysMenu
			// 
			this.SelectAnalysysMenu.Name = "SelectAnalysysMenu";
			this.SelectAnalysysMenu.Size = new System.Drawing.Size(263, 22);
			this.SelectAnalysysMenu.Text = "Select obj or sourcr";
			this.SelectAnalysysMenu.Click += new System.EventHandler(this.SelectAnalysysMenu_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// ctsScomp1
			// 
			this.ctsScomp1.CTSSPath = "";
			this.ctsScomp1.Option = CTSS.OPT.G;
			this.ctsScomp1.OptionFilePath = "";
			this.ctsScomp1.PdbPath = "";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 421);
			this.Controls.Add(this.tbCmd);
			this.Controls.Add(this.btnBatch);
			this.Controls.Add(this.btnExec);
			this.Controls.Add(this.gbOptions);
			this.Controls.Add(this.btnPdb);
			this.Controls.Add(this.tbPdb);
			this.Controls.Add(this.btnSelectExe);
			this.Controls.Add(this.tbExe);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(3000, 460);
			this.MinimumSize = new System.Drawing.Size(450, 460);
			this.Name = "Form1";
			this.Text = "CheckThreadSafeSymbols.exe Frontend";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.gbOptions.ResumeLayout(false);
			this.gbOptions.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbExe;
		private System.Windows.Forms.Button btnSelectExe;
		private System.Windows.Forms.Button btnPdb;
		private System.Windows.Forms.TextBox tbPdb;
		private System.Windows.Forms.GroupBox gbOptions;
		private System.Windows.Forms.Button btnAna;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.TextBox tbAna;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb0;
		private System.Windows.Forms.Button btnExec;
		private System.Windows.Forms.Button btnBatch;
		private System.Windows.Forms.TextBox tbCmd;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SelectExeMenu;
		private System.Windows.Forms.ToolStripMenuItem SelectPdpMenu;
		private System.Windows.Forms.ToolStripMenuItem SelectAnalysysMenu;
		private CTSScomp ctsScomp1;
	}
}

