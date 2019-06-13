namespace AE_sdk_util
{
	partial class AE_VersionForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.numMajor = new System.Windows.Forms.NumericUpDown();
			this.numMinor = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numBug = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numBuild = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbStage = new System.Windows.Forms.ComboBox();
			this.numVersion = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numMajor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBug)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBuild)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numVersion)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "MAJOR VERSION";
			// 
			// numMajor
			// 
			this.numMajor.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numMajor.Location = new System.Drawing.Point(143, 7);
			this.numMajor.Name = "numMajor";
			this.numMajor.Size = new System.Drawing.Size(152, 23);
			this.numMajor.TabIndex = 1;
			this.numMajor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMajor.ValueChanged += new System.EventHandler(this.numMajor_ValueChanged);
			// 
			// numMinor
			// 
			this.numMinor.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numMinor.Location = new System.Drawing.Point(143, 40);
			this.numMinor.Name = "numMinor";
			this.numMinor.Size = new System.Drawing.Size(152, 23);
			this.numMinor.TabIndex = 3;
			this.numMinor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMinor.ValueChanged += new System.EventHandler(this.numMajor_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(7, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "MINOR VERSION";
			// 
			// numBug
			// 
			this.numBug.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numBug.Location = new System.Drawing.Point(143, 73);
			this.numBug.Name = "numBug";
			this.numBug.Size = new System.Drawing.Size(152, 23);
			this.numBug.TabIndex = 5;
			this.numBug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numBug.ValueChanged += new System.EventHandler(this.numMajor_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(7, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "BUG VERSION";
			// 
			// numBuild
			// 
			this.numBuild.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numBuild.Location = new System.Drawing.Point(143, 139);
			this.numBuild.Name = "numBuild";
			this.numBuild.Size = new System.Drawing.Size(152, 23);
			this.numBuild.TabIndex = 7;
			this.numBuild.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numBuild.ValueChanged += new System.EventHandler(this.numMajor_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(7, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "BUILD VERSION";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(7, 109);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "STAGE VERSION";
			// 
			// cmbStage
			// 
			this.cmbStage.FormattingEnabled = true;
			this.cmbStage.Items.AddRange(new object[] {
            "\tPF_Stage_DEVELOP",
            "PF_Stage_ALPHA",
            "PF_Stage_BETA",
            "PF_Stage_RELEASE"});
			this.cmbStage.Location = new System.Drawing.Point(143, 107);
			this.cmbStage.Name = "cmbStage";
			this.cmbStage.Size = new System.Drawing.Size(153, 20);
			this.cmbStage.TabIndex = 9;
			this.cmbStage.SelectedValueChanged += new System.EventHandler(this.numMajor_ValueChanged);
			// 
			// numVersion
			// 
			this.numVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numVersion.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numVersion.Location = new System.Drawing.Point(69, 207);
			this.numVersion.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.numVersion.Name = "numVersion";
			this.numVersion.Size = new System.Drawing.Size(226, 31);
			this.numVersion.TabIndex = 10;
			this.numVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label6.Location = new System.Drawing.Point(7, 182);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(135, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "AE_Effects_Version";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "#define\tMAJOR_VERSION\t1",
            "#define\tMINOR_VERSION\t0",
            "#define\tBUG_VERSION\t\t0",
            "#define\tSTAGE_VERSION\t\tPF_Stage_DEVELOP",
            "#define\tBUILD_VERSION\t1",
            "#define VERSION 524290\t//AE_Effects_Version.exeで上記計算して求める"});
			this.textBox1.Location = new System.Drawing.Point(301, 10);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(381, 228);
			this.textBox1.TabIndex = 12;
			this.textBox1.Text = "#define\tMAJOR_VERSION\t1\\r\\n";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(107, 244);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Peast";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(188, 245);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 14;
			this.button2.Text = "Copy";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(604, 245);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 15;
			this.button3.Text = "Copy Code";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// AE_VersionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 282);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numVersion);
			this.Controls.Add(this.cmbStage);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numBuild);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numBug);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numMinor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numMajor);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "AE_VersionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "AE_Effects_Version";
			((System.ComponentModel.ISupportInitialize)(this.numMajor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBug)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBuild)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numVersion)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numMajor;
		private System.Windows.Forms.NumericUpDown numMinor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numBug;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numBuild;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbStage;
		private System.Windows.Forms.NumericUpDown numVersion;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}