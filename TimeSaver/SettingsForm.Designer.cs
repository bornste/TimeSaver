namespace TimeSaver
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_flwButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.m_dlgColor = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_tblAppearance = new System.Windows.Forms.TableLayoutPanel();
            this.m_btnColorText = new System.Windows.Forms.Button();
            this.m_btnColorBack = new System.Windows.Forms.Button();
            this.m_btnReset = new System.Windows.Forms.Button();
            this.m_lblPreview = new System.Windows.Forms.Label();
            this.m_chkUpperCase = new System.Windows.Forms.CheckBox();
            this.m_chkBlinkSeconds = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rbDisplayAll = new System.Windows.Forms.RadioButton();
            this.m_rbDisplayPrimary = new System.Windows.Forms.RadioButton();
            this.m_flwButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_tblAppearance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnSave
            // 
            this.m_btnSave.AccessibleDescription = null;
            this.m_btnSave.AccessibleName = null;
            resources.ApplyResources(this.m_btnSave, "m_btnSave");
            this.m_btnSave.BackgroundImage = null;
            this.m_btnSave.Font = null;
            this.m_btnSave.MinimumSize = new System.Drawing.Size(80, 0);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.UseVisualStyleBackColor = false;
            this.m_btnSave.Click += new System.EventHandler(this.OnSave_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AccessibleDescription = null;
            this.m_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.BackgroundImage = null;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Font = null;
            this.m_btnCancel.MinimumSize = new System.Drawing.Size(80, 0);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.OnCancel_Click);
            // 
            // m_flwButtons
            // 
            this.m_flwButtons.AccessibleDescription = null;
            this.m_flwButtons.AccessibleName = null;
            resources.ApplyResources(this.m_flwButtons, "m_flwButtons");
            this.m_flwButtons.BackgroundImage = null;
            this.m_flwButtons.Controls.Add(this.m_btnCancel);
            this.m_flwButtons.Controls.Add(this.m_btnSave);
            this.m_flwButtons.Font = null;
            this.m_flwButtons.Name = "m_flwButtons";
            // 
            // m_dlgColor
            // 
            this.m_dlgColor.AnyColor = true;
            this.m_dlgColor.FullOpen = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.m_tblAppearance);
            this.groupBox1.Controls.Add(this.m_chkUpperCase);
            this.groupBox1.Controls.Add(this.m_chkBlinkSeconds);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_tblAppearance
            // 
            this.m_tblAppearance.AccessibleDescription = null;
            this.m_tblAppearance.AccessibleName = null;
            resources.ApplyResources(this.m_tblAppearance, "m_tblAppearance");
            this.m_tblAppearance.BackgroundImage = null;
            this.m_tblAppearance.Controls.Add(this.m_btnColorText, 1, 0);
            this.m_tblAppearance.Controls.Add(this.m_btnColorBack, 1, 1);
            this.m_tblAppearance.Controls.Add(this.m_btnReset, 1, 2);
            this.m_tblAppearance.Controls.Add(this.m_lblPreview, 0, 0);
            this.m_tblAppearance.Font = null;
            this.m_tblAppearance.Name = "m_tblAppearance";
            // 
            // m_btnColorText
            // 
            this.m_btnColorText.AccessibleDescription = null;
            this.m_btnColorText.AccessibleName = null;
            resources.ApplyResources(this.m_btnColorText, "m_btnColorText");
            this.m_btnColorText.BackgroundImage = null;
            this.m_btnColorText.Font = null;
            this.m_btnColorText.MinimumSize = new System.Drawing.Size(80, 0);
            this.m_btnColorText.Name = "m_btnColorText";
            this.m_btnColorText.UseVisualStyleBackColor = true;
            this.m_btnColorText.Click += new System.EventHandler(this.OnTextColor_Click);
            // 
            // m_btnColorBack
            // 
            this.m_btnColorBack.AccessibleDescription = null;
            this.m_btnColorBack.AccessibleName = null;
            resources.ApplyResources(this.m_btnColorBack, "m_btnColorBack");
            this.m_btnColorBack.BackgroundImage = null;
            this.m_btnColorBack.Font = null;
            this.m_btnColorBack.MinimumSize = new System.Drawing.Size(80, 0);
            this.m_btnColorBack.Name = "m_btnColorBack";
            this.m_btnColorBack.UseVisualStyleBackColor = true;
            this.m_btnColorBack.Click += new System.EventHandler(this.OnBackgroundColor_Click);
            // 
            // m_btnReset
            // 
            this.m_btnReset.AccessibleDescription = null;
            this.m_btnReset.AccessibleName = null;
            resources.ApplyResources(this.m_btnReset, "m_btnReset");
            this.m_btnReset.BackgroundImage = null;
            this.m_btnReset.Font = null;
            this.m_btnReset.MinimumSize = new System.Drawing.Size(80, 0);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.UseVisualStyleBackColor = true;
            this.m_btnReset.Click += new System.EventHandler(this.OnReset_Click);
            // 
            // m_lblPreview
            // 
            this.m_lblPreview.AccessibleDescription = null;
            this.m_lblPreview.AccessibleName = null;
            resources.ApplyResources(this.m_lblPreview, "m_lblPreview");
            this.m_lblPreview.BackColor = System.Drawing.Color.Black;
            this.m_lblPreview.ForeColor = System.Drawing.Color.White;
            this.m_lblPreview.Name = "m_lblPreview";
            this.m_tblAppearance.SetRowSpan(this.m_lblPreview, 3);
            // 
            // m_chkUpperCase
            // 
            this.m_chkUpperCase.AccessibleDescription = null;
            this.m_chkUpperCase.AccessibleName = null;
            resources.ApplyResources(this.m_chkUpperCase, "m_chkUpperCase");
            this.m_chkUpperCase.BackgroundImage = null;
            this.m_chkUpperCase.Font = null;
            this.m_chkUpperCase.Name = "m_chkUpperCase";
            this.m_chkUpperCase.UseVisualStyleBackColor = true;
            this.m_chkUpperCase.CheckedChanged += new System.EventHandler(this.OnUpperCase_CheckedChanged);
            // 
            // m_chkBlinkSeconds
            // 
            this.m_chkBlinkSeconds.AccessibleDescription = null;
            this.m_chkBlinkSeconds.AccessibleName = null;
            resources.ApplyResources(this.m_chkBlinkSeconds, "m_chkBlinkSeconds");
            this.m_chkBlinkSeconds.BackgroundImage = null;
            this.m_chkBlinkSeconds.Font = null;
            this.m_chkBlinkSeconds.Name = "m_chkBlinkSeconds";
            this.m_chkBlinkSeconds.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.m_rbDisplayAll);
            this.groupBox2.Controls.Add(this.m_rbDisplayPrimary);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_rbDisplayAll
            // 
            this.m_rbDisplayAll.AccessibleDescription = null;
            this.m_rbDisplayAll.AccessibleName = null;
            resources.ApplyResources(this.m_rbDisplayAll, "m_rbDisplayAll");
            this.m_rbDisplayAll.BackgroundImage = null;
            this.m_rbDisplayAll.Font = null;
            this.m_rbDisplayAll.Name = "m_rbDisplayAll";
            this.m_rbDisplayAll.UseVisualStyleBackColor = true;
            // 
            // m_rbDisplayPrimary
            // 
            this.m_rbDisplayPrimary.AccessibleDescription = null;
            this.m_rbDisplayPrimary.AccessibleName = null;
            resources.ApplyResources(this.m_rbDisplayPrimary, "m_rbDisplayPrimary");
            this.m_rbDisplayPrimary.BackgroundImage = null;
            this.m_rbDisplayPrimary.Checked = true;
            this.m_rbDisplayPrimary.Font = null;
            this.m_rbDisplayPrimary.Name = "m_rbDisplayPrimary";
            this.m_rbDisplayPrimary.TabStop = true;
            this.m_rbDisplayPrimary.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.m_btnSave;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_flwButtons);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.OnHelpButton_Clicked);
            this.m_flwButtons.ResumeLayout(false);
            this.m_flwButtons.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_tblAppearance.ResumeLayout(false);
            this.m_tblAppearance.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.FlowLayoutPanel m_flwButtons;
        private System.Windows.Forms.ColorDialog m_dlgColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton m_rbDisplayAll;
        private System.Windows.Forms.RadioButton m_rbDisplayPrimary;
        private System.Windows.Forms.Button m_btnColorBack;
        private System.Windows.Forms.Button m_btnColorText;
        private System.Windows.Forms.Label m_lblPreview;
        private System.Windows.Forms.Button m_btnReset;
        private System.Windows.Forms.CheckBox m_chkBlinkSeconds;
        private System.Windows.Forms.CheckBox m_chkUpperCase;
        private System.Windows.Forms.TableLayoutPanel m_tblAppearance;

    }
}