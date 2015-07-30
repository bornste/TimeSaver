namespace TimeSaver
{
    partial class ScreensaverForm
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
            this.m_ctlHours = new TimeSaver.DisplayControl();
            this.m_ctlWeekday = new TimeSaver.DisplayControl();
            this.m_ctlDate = new TimeSaver.DisplayControl();
            this.m_pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.m_ctlSeparator = new TimeSaver.DisplayControl();
            this.m_ctlMinutes = new TimeSaver.DisplayControl();
            this.m_pnlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctlHours
            // 
            this.m_ctlHours.BackColor = System.Drawing.Color.Black;
            this.m_ctlHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlHours.Font = new System.Drawing.Font("TimeSaver", 30F, System.Drawing.FontStyle.Bold);
            this.m_ctlHours.FontType = TimeSaver.FontType.Bold;
            this.m_ctlHours.ForeColor = System.Drawing.Color.White;
            this.m_ctlHours.Location = new System.Drawing.Point(0, 88);
            this.m_ctlHours.Margin = new System.Windows.Forms.Padding(0);
            this.m_ctlHours.Name = "m_ctlHours";
            this.m_ctlHours.Size = new System.Drawing.Size(339, 123);
            this.m_ctlHours.TabIndex = 0;
            this.m_ctlHours.Text = "22";
            this.m_ctlHours.TextAlign = System.Drawing.StringAlignment.Far;
            this.m_ctlHours.VerticalOffset = 3;
            // 
            // m_ctlWeekday
            // 
            this.m_ctlWeekday.BackColor = System.Drawing.Color.Black;
            this.m_pnlLayout.SetColumnSpan(this.m_ctlWeekday, 3);
            this.m_ctlWeekday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlWeekday.Font = new System.Drawing.Font("TimeSaver", 30F);
            this.m_ctlWeekday.FontType = TimeSaver.FontType.Light;
            this.m_ctlWeekday.ForeColor = System.Drawing.Color.White;
            this.m_ctlWeekday.Location = new System.Drawing.Point(0, 211);
            this.m_ctlWeekday.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.m_ctlWeekday.Name = "m_ctlWeekday";
            this.m_ctlWeekday.Size = new System.Drawing.Size(705, 46);
            this.m_ctlWeekday.TabIndex = 0;
            this.m_ctlWeekday.Text = "Donnerstag";
            // 
            // m_ctlDate
            // 
            this.m_ctlDate.BackColor = System.Drawing.Color.Black;
            this.m_pnlLayout.SetColumnSpan(this.m_ctlDate, 3);
            this.m_ctlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlDate.Font = new System.Drawing.Font("TimeSaver", 30F);
            this.m_ctlDate.FontType = TimeSaver.FontType.Light;
            this.m_ctlDate.ForeColor = System.Drawing.Color.White;
            this.m_ctlDate.Location = new System.Drawing.Point(0, 259);
            this.m_ctlDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.m_ctlDate.Name = "m_ctlDate";
            this.m_ctlDate.Size = new System.Drawing.Size(705, 46);
            this.m_ctlDate.TabIndex = 0;
            this.m_ctlDate.Text = "22. November 2022";
            // 
            // m_pnlLayout
            // 
            this.m_pnlLayout.ColumnCount = 3;
            this.m_pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.m_pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_pnlLayout.Controls.Add(this.m_ctlSeparator, 1, 1);
            this.m_pnlLayout.Controls.Add(this.m_ctlHours, 0, 1);
            this.m_pnlLayout.Controls.Add(this.m_ctlDate, 0, 3);
            this.m_pnlLayout.Controls.Add(this.m_ctlWeekday, 0, 2);
            this.m_pnlLayout.Controls.Add(this.m_ctlMinutes, 2, 1);
            this.m_pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlLayout.Location = new System.Drawing.Point(0, 0);
            this.m_pnlLayout.Name = "m_pnlLayout";
            this.m_pnlLayout.RowCount = 5;
            this.m_pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.m_pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.m_pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.m_pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.m_pnlLayout.Size = new System.Drawing.Size(705, 442);
            this.m_pnlLayout.TabIndex = 1;
            // 
            // m_ctlSeparator
            // 
            this.m_ctlSeparator.AutoSize = true;
            this.m_ctlSeparator.BackColor = System.Drawing.Color.Black;
            this.m_ctlSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlSeparator.Font = new System.Drawing.Font("TimeSaver", 30F, System.Drawing.FontStyle.Bold);
            this.m_ctlSeparator.FontType = TimeSaver.FontType.Bold;
            this.m_ctlSeparator.ForeColor = System.Drawing.Color.White;
            this.m_ctlSeparator.Location = new System.Drawing.Point(339, 88);
            this.m_ctlSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.m_ctlSeparator.Name = "m_ctlSeparator";
            this.m_ctlSeparator.Padding = new System.Windows.Forms.Padding(2, 10, 2, 12);
            this.m_ctlSeparator.Size = new System.Drawing.Size(27, 123);
            this.m_ctlSeparator.TabIndex = 2;
            this.m_ctlSeparator.Text = ":";
            this.m_ctlSeparator.UseFading = true;
            this.m_ctlSeparator.VerticalOffset = 2;
            // 
            // m_ctlMinutes
            // 
            this.m_ctlMinutes.BackColor = System.Drawing.Color.Black;
            this.m_ctlMinutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlMinutes.Font = new System.Drawing.Font("TimeSaver", 30F, System.Drawing.FontStyle.Bold);
            this.m_ctlMinutes.FontType = TimeSaver.FontType.Bold;
            this.m_ctlMinutes.ForeColor = System.Drawing.Color.White;
            this.m_ctlMinutes.Location = new System.Drawing.Point(366, 88);
            this.m_ctlMinutes.Margin = new System.Windows.Forms.Padding(0);
            this.m_ctlMinutes.Name = "m_ctlMinutes";
            this.m_ctlMinutes.Size = new System.Drawing.Size(339, 123);
            this.m_ctlMinutes.TabIndex = 0;
            this.m_ctlMinutes.Text = "59";
            this.m_ctlMinutes.TextAlign = System.Drawing.StringAlignment.Near;
            this.m_ctlMinutes.VerticalOffset = 3;
            // 
            // ScreensaverForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(705, 442);
            this.Controls.Add(this.m_pnlLayout);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreensaverForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.TopMost = true;
            this.m_pnlLayout.ResumeLayout(false);
            this.m_pnlLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DisplayControl m_ctlHours;
        private DisplayControl m_ctlWeekday;
        private DisplayControl m_ctlDate;
        private System.Windows.Forms.TableLayoutPanel m_pnlLayout;
        private DisplayControl m_ctlSeparator;
        private DisplayControl m_ctlMinutes;


    }
}

