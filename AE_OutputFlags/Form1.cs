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

    public partial class Form1 : Form
    {
        // *****************************************************************************************
        private AE_VersionForm versionForm = null;
        // *****************************************************************************************
        public Form1()
        {
            InitializeComponent();

        }
        // *****************************************************************************************
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.UserAppDataPath, "AE_Effect.json");

            if (File.Exists(filePath))
            {
                aE_Effect1.Import(filePath);
            }
            else
            {
                string pp = Path.Combine( Path.GetDirectoryName(Application.ExecutablePath), "AE_Effect.json");
                if (File.Exists(pp))
                {
                    aE_Effect1.Import(pp);
                }
                else
                {
                    MessageBox.Show("Please import AE_Effect.h");
                }
            }

            JsonPref pref = new JsonPref();
            if (pref.Load())
            {
                bool ok;
                Size sz = pref.GetSize("Size", out ok);
                if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                int sd = pref.GetInt("SplitDistance1", out ok);
                if (ok) splitContainer1.SplitterDistance = sd;
                sd = pref.GetInt("SplitDistance2", out ok);
                if (ok) splitContainer2.SplitterDistance = sd;
                sd = pref.GetInt("SplitDistance3", out ok);
                if (ok) splitContainer3.SplitterDistance = sd;

            }
            



        }
        // *****************************************************************************************
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string filePath = Path.Combine(Application.UserAppDataPath, "AE_Effect.json");
            aE_Effect1.Export(filePath);

            //設定ファイルの保存
            JsonPref pref = new JsonPref();
            pref.SetSize("Size", this.Size);
            pref.SetPoint("Point", this.Location);
            pref.SetInt("SplitDistance1", splitContainer1.SplitterDistance);
            pref.SetInt("SplitDistance2", splitContainer2.SplitterDistance);
            pref.SetInt("SplitDistance3", splitContainer3.SplitterDistance);
            pref.Save();


        }
        // *****************************************************************************************
        public void ShowVersionEditor()
        {
           
            if (versionForm == null)
            {
                versionForm = new AE_VersionForm();
                versionForm.FormClosed += VersionForm_FormClosed;
            }
            versionForm.Show();
            versionForm.Activate();
            versionForm.TopMost = true;
            versionForm.TopMost = false;

        }

        private void VersionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            versionForm = null;
        }
        // *****************************************************************************************
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (aE_Effect1.AE_EffectH != "")
            {
                dlg.InitialDirectory = Path.GetDirectoryName(aE_Effect1.AE_EffectH);
                dlg.FileName = "AE_Effect.h";
            }


            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    aE_Effect1.LoadAE_EffectH(dlg.FileName);
                }
            }
            finally
            {
                dlg.Dispose();
            }
        }

        // *****************************************************************************************
        private void btnExportJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (aE_Effect1.AE_EffectH != "")
            {
                dlg.InitialDirectory = Path.GetDirectoryName(aE_Effect1.AE_EffectH);
                dlg.FileName = "AE_Effect.json";
            }
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    aE_Effect1.Export(dlg.FileName);
                }
            }
            finally
            {
                dlg.Dispose();
            }

        }
        // *****************************************************************************************
        private void btnImportJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    aE_Effect1.Import(dlg.FileName);
                }
            }
            finally
            {
                dlg.Dispose();
            }
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            ShowVersionEditor();
        }
        
    }
}
