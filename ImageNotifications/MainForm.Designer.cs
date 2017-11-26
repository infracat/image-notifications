namespace ImageNotifications
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.checkBoxSafe = new System.Windows.Forms.CheckBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.timerInterval = new System.Windows.Forms.Timer(this.components);
            this.groupBoxConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Text = "Image Notifications";
            this.notifyIconTray.Visible = true;
            // 
            // groupBoxConfiguration
            // 
            this.groupBoxConfiguration.Controls.Add(this.labelInterval);
            this.groupBoxConfiguration.Controls.Add(this.numericUpDownInterval);
            this.groupBoxConfiguration.Controls.Add(this.buttonRemoveTag);
            this.groupBoxConfiguration.Controls.Add(this.buttonAddTag);
            this.groupBoxConfiguration.Controls.Add(this.checkBoxSafe);
            this.groupBoxConfiguration.Controls.Add(this.textBoxTags);
            this.groupBoxConfiguration.Controls.Add(this.listBoxTags);
            this.groupBoxConfiguration.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConfiguration.Name = "groupBoxConfiguration";
            this.groupBoxConfiguration.Size = new System.Drawing.Size(360, 142);
            this.groupBoxConfiguration.TabIndex = 0;
            this.groupBoxConfiguration.TabStop = false;
            this.groupBoxConfiguration.Text = "Tags";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(213, 110);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(101, 13);
            this.labelInterval.TabIndex = 6;
            this.labelInterval.Text = "Check Interval (min)";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(319, 107);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.ReadOnly = true;
            this.numericUpDownInterval.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownInterval.TabIndex = 5;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownInterval_ValueChanged);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Enabled = false;
            this.buttonRemoveTag.Location = new System.Drawing.Point(184, 105);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(23, 23);
            this.buttonRemoveTag.TabIndex = 4;
            this.buttonRemoveTag.Text = "-";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(155, 105);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(23, 23);
            this.buttonAddTag.TabIndex = 3;
            this.buttonAddTag.Text = "+";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // checkBoxSafe
            // 
            this.checkBoxSafe.AutoSize = true;
            this.checkBoxSafe.Checked = true;
            this.checkBoxSafe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSafe.Location = new System.Drawing.Point(216, 19);
            this.checkBoxSafe.Name = "checkBoxSafe";
            this.checkBoxSafe.Size = new System.Drawing.Size(81, 17);
            this.checkBoxSafe.TabIndex = 2;
            this.checkBoxSafe.Text = "Safety Filter";
            this.checkBoxSafe.UseVisualStyleBackColor = true;
            this.checkBoxSafe.CheckedChanged += new System.EventHandler(this.checkBoxSafe_CheckedChanged);
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(6, 107);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(143, 20);
            this.textBoxTags.TabIndex = 1;
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(6, 19);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(201, 82);
            this.listBoxTags.TabIndex = 0;
            this.listBoxTags.SelectedIndexChanged += new System.EventHandler(this.listBoxTags_SelectedIndexChanged);
            // 
            // timerInterval
            // 
            this.timerInterval.Interval = 60000;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 166);
            this.Controls.Add(this.groupBoxConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Notifications";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxConfiguration.ResumeLayout(false);
            this.groupBoxConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.GroupBox groupBoxConfiguration;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.Button buttonRemoveTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.CheckBox checkBoxSafe;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Timer timerInterval;
    }
}

