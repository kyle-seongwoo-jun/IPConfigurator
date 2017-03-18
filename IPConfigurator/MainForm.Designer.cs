namespace IPConfigurator
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StaticRadioButton = new System.Windows.Forms.RadioButton();
            this.DynamicRadioButton = new System.Windows.Forms.RadioButton();
            this.RadioButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GradeLabel = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.AdapterComboBox = new System.Windows.Forms.ComboBox();
            this.AdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NumberComboBox = new System.Windows.Forms.ComboBox();
            this.NumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GradeComboBox = new System.Windows.Forms.ComboBox();
            this.GradeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AdapterLabel = new System.Windows.Forms.Label();
            this.IPButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutThisProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.ClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RadioButtonGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdapterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeBindingSource)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StaticRadioButton
            // 
            this.StaticRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StaticRadioButton.AutoSize = true;
            this.StaticRadioButton.Checked = true;
            this.StaticRadioButton.Location = new System.Drawing.Point(6, 20);
            this.StaticRadioButton.Name = "StaticRadioButton";
            this.StaticRadioButton.Size = new System.Drawing.Size(54, 16);
            this.StaticRadioButton.TabIndex = 3;
            this.StaticRadioButton.TabStop = true;
            this.StaticRadioButton.Text = "Static";
            this.StaticRadioButton.UseVisualStyleBackColor = true;
            this.StaticRadioButton.CheckedChanged += new System.EventHandler(this.StaticRadioButton_CheckedChanged);
            // 
            // DynamicRadioButton
            // 
            this.DynamicRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DynamicRadioButton.AutoSize = true;
            this.DynamicRadioButton.Location = new System.Drawing.Point(72, 20);
            this.DynamicRadioButton.Name = "DynamicRadioButton";
            this.DynamicRadioButton.Size = new System.Drawing.Size(73, 16);
            this.DynamicRadioButton.TabIndex = 4;
            this.DynamicRadioButton.Text = "Dynamic";
            this.DynamicRadioButton.UseVisualStyleBackColor = true;
            // 
            // RadioButtonGroupBox
            // 
            this.RadioButtonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonGroupBox.Controls.Add(this.StaticRadioButton);
            this.RadioButtonGroupBox.Controls.Add(this.DynamicRadioButton);
            this.RadioButtonGroupBox.Location = new System.Drawing.Point(19, 56);
            this.RadioButtonGroupBox.Name = "RadioButtonGroupBox";
            this.RadioButtonGroupBox.Size = new System.Drawing.Size(151, 47);
            this.RadioButtonGroupBox.TabIndex = 2;
            this.RadioButtonGroupBox.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(424, 86);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GradeLabel
            // 
            this.GradeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradeLabel.AutoSize = true;
            this.GradeLabel.Location = new System.Drawing.Point(182, 67);
            this.GradeLabel.Name = "GradeLabel";
            this.GradeLabel.Size = new System.Drawing.Size(39, 12);
            this.GradeLabel.TabIndex = 6;
            this.GradeLabel.Text = "Grade";
            // 
            // NumberLabel
            // 
            this.NumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(182, 89);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(50, 12);
            this.NumberLabel.TabIndex = 7;
            this.NumberLabel.Text = "Number";
            // 
            // AdapterComboBox
            // 
            this.AdapterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdapterComboBox.DataSource = this.AdapterBindingSource;
            this.AdapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AdapterComboBox.Location = new System.Drawing.Point(73, 33);
            this.AdapterComboBox.Name = "AdapterComboBox";
            this.AdapterComboBox.Size = new System.Drawing.Size(398, 20);
            this.AdapterComboBox.TabIndex = 1;
            this.AdapterComboBox.SelectedIndexChanged += new System.EventHandler(this.AdapterComboBox_SelectedIndexChanged);
            // 
            // NumberComboBox
            // 
            this.NumberComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberComboBox.DataSource = this.NumberBindingSource;
            this.NumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberComboBox.FormattingEnabled = true;
            this.NumberComboBox.Location = new System.Drawing.Point(238, 86);
            this.NumberComboBox.Name = "NumberComboBox";
            this.NumberComboBox.Size = new System.Drawing.Size(173, 20);
            this.NumberComboBox.TabIndex = 7;
            // 
            // GradeComboBox
            // 
            this.GradeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradeComboBox.DataSource = this.GradeBindingSource;
            this.GradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GradeComboBox.FormattingEnabled = true;
            this.GradeComboBox.Location = new System.Drawing.Point(238, 60);
            this.GradeComboBox.Name = "GradeComboBox";
            this.GradeComboBox.Size = new System.Drawing.Size(64, 20);
            this.GradeComboBox.TabIndex = 5;
            this.GradeComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // AdapterLabel
            // 
            this.AdapterLabel.AutoSize = true;
            this.AdapterLabel.Location = new System.Drawing.Point(18, 36);
            this.AdapterLabel.Name = "AdapterLabel";
            this.AdapterLabel.Size = new System.Drawing.Size(48, 12);
            this.AdapterLabel.TabIndex = 12;
            this.AdapterLabel.Text = "Adapter";
            // 
            // IPButton
            // 
            this.IPButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IPButton.Location = new System.Drawing.Point(424, 58);
            this.IPButton.Name = "IPButton";
            this.IPButton.Size = new System.Drawing.Size(75, 23);
            this.IPButton.TabIndex = 8;
            this.IPButton.Text = "IP";
            this.IPButton.UseVisualStyleBackColor = true;
            this.IPButton.Click += new System.EventHandler(this.IPButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.BackgroundImage = global::IPConfigurator.Properties.Resources.rotate_left_512;
            this.ReloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReloadButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ReloadButton.Location = new System.Drawing.Point(477, 31);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(23, 23);
            this.ReloadButton.TabIndex = 2;
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(511, 24);
            this.MenuStrip.TabIndex = 15;
            this.MenuStrip.Text = "menuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.FileToolStripMenuItem.Text = "File(&F)";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ExitToolStripMenuItem.Text = "Exit(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpTopicsToolStripMenuItem,
            this.ToolStripSeparator1,
            this.AboutThisProgramToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.HelpToolStripMenuItem.Text = "Help(&H)";
            // 
            // HelpTopicsToolStripMenuItem
            // 
            this.HelpTopicsToolStripMenuItem.Name = "HelpTopicsToolStripMenuItem";
            this.HelpTopicsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.HelpTopicsToolStripMenuItem.Text = "Help Topics(&H)";
            this.HelpTopicsToolStripMenuItem.Click += new System.EventHandler(this.HelpTopicsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // AboutThisProgramToolStripMenuItem
            // 
            this.AboutThisProgramToolStripMenuItem.Name = "AboutThisProgramToolStripMenuItem";
            this.AboutThisProgramToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.AboutThisProgramToolStripMenuItem.Text = "About This Program(&A)";
            this.AboutThisProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutThisProgramToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Class";
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.DataSource = this.ClassBindingSource;
            this.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(349, 60);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(62, 20);
            this.ClassComboBox.TabIndex = 6;
            this.ClassComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(511, 116);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.IPButton);
            this.Controls.Add(this.AdapterLabel);
            this.Controls.Add(this.GradeComboBox);
            this.Controls.Add(this.NumberComboBox);
            this.Controls.Add(this.AdapterComboBox);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.GradeLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RadioButtonGroupBox);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "IP Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.RadioButtonGroupBox.ResumeLayout(false);
            this.RadioButtonGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdapterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeBindingSource)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton StaticRadioButton;
		private System.Windows.Forms.RadioButton DynamicRadioButton;
		private System.Windows.Forms.GroupBox RadioButtonGroupBox;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Label GradeLabel;
		private System.Windows.Forms.Label NumberLabel;
		private System.Windows.Forms.ComboBox AdapterComboBox;
		private System.Windows.Forms.ComboBox NumberComboBox;
		private System.Windows.Forms.BindingSource AdapterBindingSource;
		private System.Windows.Forms.ComboBox GradeComboBox;
		private System.Windows.Forms.Label AdapterLabel;
		private System.Windows.Forms.Button IPButton;
		private System.Windows.Forms.BindingSource NumberBindingSource;
		private System.Windows.Forms.BindingSource GradeBindingSource;
		private System.Windows.Forms.Button ReloadButton;
		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpTopicsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem AboutThisProgramToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ClassComboBox;
		private System.Windows.Forms.BindingSource ClassBindingSource;
	}
}

