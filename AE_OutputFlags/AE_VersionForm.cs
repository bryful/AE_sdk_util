using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Codeplex.Data;

using BRY;


namespace AE_OutputFlags
{
    public partial class AE_VersionForm : Form
    {
        private bool refFlag = false;
        private AE_Version Ae_Version = new AE_Version();
        public AE_VersionForm()
        {
            InitializeComponent();
            cmbStage.SelectedIndex = 0;
            numVersion.Value = (decimal)Ae_Version.AEVersion;
            DispCode();
        }

        private void numMajor_ValueChanged(object sender, EventArgs e)
        {
            if (refFlag) return;
            string nm = (string)((Control)sender).Name;
            switch (nm)
            {
                case "numMajor":
                    Ae_Version.Major_Version = (ulong)numMajor.Value;
                    break;
                case "numMinor":
                    Ae_Version.Minor_Version = (ulong)numMinor.Value;
                    break;
                case "cmbStage":
                    if (cmbStage.SelectedIndex >= 0)
                    {
                        Ae_Version.Stage_Version = (ulong)cmbStage.SelectedIndex;
                    }
                    break;
                case "numBug":
                    Ae_Version.Bug_Version = (ulong)numBug.Value;
                    break;
                case "numBuild":
                    Ae_Version.Build_Version = (ulong)numBuild.Value;
                    break;
            }
            refFlag = true;
            numVersion.Value = (decimal)Ae_Version.AEVersion;
            refFlag = false;
            DispCode();
        }
        private void DispCode()
        {

            if (cmbStage.SelectedIndex < 0) cmbStage.SelectedIndex = 0;

            textBox1.Text = Ae_Version.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numVersion_ValueChanged(object sender, EventArgs e)
        {
            VersionChange();
        }
        private void VersionChange()
        {
            if (refFlag) return;
            if (Ae_Version.AEVersion != (ulong)numVersion.Value)
            {
                refFlag = true;
                Ae_Version.AEVersion = (ulong)numVersion.Value;
                numMajor.Value = (decimal)Ae_Version.Major_Version;
                numMinor.Value = (decimal)Ae_Version.Minor_Version;
                cmbStage.SelectedIndex = (int)Ae_Version.Stage_Version;
                numBug.Value = (decimal)Ae_Version.Bug_Version;
                numBuild.Value = (decimal)Ae_Version.Build_Version;
                refFlag = false;
                DispCode();
            }

        }

        private void numVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            VersionChange();
        }

        private void numVersion_KeyUp(object sender, KeyEventArgs e)
        {
            VersionChange();
        }

        private void btnPVersion_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                ulong v;
                if (ulong.TryParse(Clipboard.GetText(), out v) == true)
                {
                    if (numVersion.Value != (decimal)v)
                    {
                        numVersion.Value = (decimal)v;
                    }
                }
            }
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }
    }
}
