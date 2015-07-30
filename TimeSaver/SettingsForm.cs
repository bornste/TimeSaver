using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TimeSaver
{
    public partial class SettingsForm : BaseForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            m_lblPreview.BackColor = Settings.Instance.BackColor;
            m_lblPreview.ForeColor = Settings.Instance.TextColor;

            m_chkBlinkSeconds.Checked = Settings.Instance.BlinkTimeSeparator;
            m_chkUpperCase.Checked = Settings.Instance.UseUpperCase;

            if (Settings.Instance.DisplayMode == DisplayMode.AllMonitors)
                m_rbDisplayAll.Checked = true;
            else
                m_rbDisplayPrimary.Checked = true;

            UpdateText();
            
            base.OnLoad(e);
        }

        private void OnTextColor_Click(object sender, EventArgs e)
        {
            m_dlgColor.Color = m_lblPreview.ForeColor;
            if (m_dlgColor.ShowDialog(this) == DialogResult.OK)
                m_lblPreview.ForeColor = m_dlgColor.Color;
        }

        private void OnBackgroundColor_Click(object sender, EventArgs e)
        {
            m_dlgColor.Color = m_lblPreview.BackColor;
            if (m_dlgColor.ShowDialog(this) == DialogResult.OK)
                m_lblPreview.BackColor = m_dlgColor.Color;
        }

        private void OnUpperCase_CheckedChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void OnReset_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            m_lblPreview.BackColor = settings.BackColor;
            m_lblPreview.ForeColor = settings.TextColor;
        }

        private void OnSave_Click(object sender, EventArgs e)
        {
            Settings.Instance.BackColor = m_lblPreview.BackColor;
            Settings.Instance.TextColor = m_lblPreview.ForeColor;
            Settings.Instance.BlinkTimeSeparator = m_chkBlinkSeconds.Checked;
            Settings.Instance.UseUpperCase = m_chkUpperCase.Checked;
            Settings.Instance.DisplayMode = 
                m_rbDisplayPrimary.Checked ? 
                DisplayMode.OnlyOnPrimaryMonitor : DisplayMode.AllMonitors;
            
            Settings.Instance.Save();

            Close();
        }

        private void OnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnHelpButton_Clicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}", AssemblyTitle, AssemblyVersion);
            sb.AppendLine();
            sb.Append(AssemblyCopyright);
            
            MessageBox.Show(sb.ToString(), AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateText()
        {
            TimeInfo info = new TimeInfo();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}{2}", info.Hours, info.TimeSeparator, info.Minutes);
            sb.AppendLine();
            sb.AppendLine(info.Day);
            sb.Append(info.Date);

            if (m_chkUpperCase.Checked)
                m_lblPreview.Text = sb.ToString().ToUpper();
            else
                m_lblPreview.Text = sb.ToString();
        }

        private string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            }
        }

        private string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
    }
}
