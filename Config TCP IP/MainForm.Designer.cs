namespace Config_TCP_IP
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
			this.staticRadioButton = new System.Windows.Forms.RadioButton();
			this.dynamicRadioButton = new System.Windows.Forms.RadioButton();
			this.radioButtonsGroupBox = new System.Windows.Forms.GroupBox();
			this.startButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.adapterComboBox = new System.Windows.Forms.ComboBox();
			this.mainFormAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.numberComboBox = new System.Windows.Forms.ComboBox();
			this.mainFormNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gradeComboBox = new System.Windows.Forms.ComboBox();
			this.mainFormGradeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.helloButton = new System.Windows.Forms.Button();
			this.recheckButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpTopicsHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutThisProgramAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.radioButtonsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainFormAdapterBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormNumberBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormGradeBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// staticRadioButton
			// 
			this.staticRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.staticRadioButton.AutoSize = true;
			this.staticRadioButton.Location = new System.Drawing.Point(6, 20);
			this.staticRadioButton.Name = "staticRadioButton";
			this.staticRadioButton.Size = new System.Drawing.Size(54, 16);
			this.staticRadioButton.TabIndex = 0;
			this.staticRadioButton.Text = "Static";
			this.staticRadioButton.UseVisualStyleBackColor = true;
			this.staticRadioButton.CheckedChanged += new System.EventHandler(this.staticRadioButton_CheckedChanged);
			// 
			// dynamicRadioButton
			// 
			this.dynamicRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dynamicRadioButton.AutoSize = true;
			this.dynamicRadioButton.Location = new System.Drawing.Point(72, 20);
			this.dynamicRadioButton.Name = "dynamicRadioButton";
			this.dynamicRadioButton.Size = new System.Drawing.Size(73, 16);
			this.dynamicRadioButton.TabIndex = 1;
			this.dynamicRadioButton.Text = "Dynamic";
			this.dynamicRadioButton.UseVisualStyleBackColor = true;
			this.dynamicRadioButton.CheckedChanged += new System.EventHandler(this.dynamicRadioButton_CheckedChanged);
			// 
			// radioButtonsGroupBox
			// 
			this.radioButtonsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButtonsGroupBox.Controls.Add(this.staticRadioButton);
			this.radioButtonsGroupBox.Controls.Add(this.dynamicRadioButton);
			this.radioButtonsGroupBox.Location = new System.Drawing.Point(19, 56);
			this.radioButtonsGroupBox.Name = "radioButtonsGroupBox";
			this.radioButtonsGroupBox.Size = new System.Drawing.Size(151, 47);
			this.radioButtonsGroupBox.TabIndex = 2;
			this.radioButtonsGroupBox.TabStop = false;
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.Location = new System.Drawing.Point(424, 86);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 3;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(182, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Grade";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(182, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "Number";
			// 
			// adapterComboBox
			// 
			this.adapterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.adapterComboBox.DataSource = this.mainFormAdapterBindingSource;
			this.adapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.adapterComboBox.Location = new System.Drawing.Point(73, 33);
			this.adapterComboBox.Name = "adapterComboBox";
			this.adapterComboBox.Size = new System.Drawing.Size(398, 20);
			this.adapterComboBox.TabIndex = 8;
			// 
			// mainFormAdapterBindingSource
			// 
			this.mainFormAdapterBindingSource.DataSource = typeof(Config_TCP_IP.MainForm);
			// 
			// numberComboBox
			// 
			this.numberComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numberComboBox.DataSource = this.mainFormNumberBindingSource;
			this.numberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.numberComboBox.FormattingEnabled = true;
			this.numberComboBox.Location = new System.Drawing.Point(238, 86);
			this.numberComboBox.Name = "numberComboBox";
			this.numberComboBox.Size = new System.Drawing.Size(173, 20);
			this.numberComboBox.TabIndex = 9;
			// 
			// mainFormNumberBindingSource
			// 
			this.mainFormNumberBindingSource.DataSource = typeof(Config_TCP_IP.MainForm);
			// 
			// gradeComboBox
			// 
			this.gradeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gradeComboBox.DataSource = this.mainFormGradeBindingSource;
			this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gradeComboBox.FormattingEnabled = true;
			this.gradeComboBox.Location = new System.Drawing.Point(238, 60);
			this.gradeComboBox.Name = "gradeComboBox";
			this.gradeComboBox.Size = new System.Drawing.Size(173, 20);
			this.gradeComboBox.TabIndex = 11;
			// 
			// mainFormGradeBindingSource
			// 
			this.mainFormGradeBindingSource.DataSource = typeof(Config_TCP_IP.MainForm);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "Adapter";
			// 
			// helloButton
			// 
			this.helloButton.Location = new System.Drawing.Point(424, 58);
			this.helloButton.Name = "helloButton";
			this.helloButton.Size = new System.Drawing.Size(75, 23);
			this.helloButton.TabIndex = 13;
			this.helloButton.Text = "My IP";
			this.helloButton.UseVisualStyleBackColor = true;
			this.helloButton.Click += new System.EventHandler(this.helloButton_Click);
			// 
			// recheckButton
			// 
			this.recheckButton.BackgroundImage = global::Config_TCP_IP.Properties.Resources.rotate_left_512;
			this.recheckButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.recheckButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.recheckButton.Location = new System.Drawing.Point(477, 31);
			this.recheckButton.Name = "recheckButton";
			this.recheckButton.Size = new System.Drawing.Size(23, 23);
			this.recheckButton.TabIndex = 14;
			this.recheckButton.UseVisualStyleBackColor = true;
			this.recheckButton.Click += new System.EventHandler(this.recheckButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.helpHToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(511, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileFToolStripMenuItem
			// 
			this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitXToolStripMenuItem});
			this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
			this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.fileFToolStripMenuItem.Text = "File(&F)";
			// 
			// exitXToolStripMenuItem
			// 
			this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
			this.exitXToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.exitXToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exitXToolStripMenuItem.Text = "Exit(&X)";
			this.exitXToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
			// 
			// helpHToolStripMenuItem
			// 
			this.helpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsHToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutThisProgramAToolStripMenuItem});
			this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
			this.helpHToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.helpHToolStripMenuItem.Text = "Help(&H)";
			// 
			// helpTopicsHToolStripMenuItem
			// 
			this.helpTopicsHToolStripMenuItem.Name = "helpTopicsHToolStripMenuItem";
			this.helpTopicsHToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			this.helpTopicsHToolStripMenuItem.Text = "Help Topics(&H)";
			this.helpTopicsHToolStripMenuItem.Click += new System.EventHandler(this.helpTopicsHToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
			// 
			// aboutThisProgramAToolStripMenuItem
			// 
			this.aboutThisProgramAToolStripMenuItem.Name = "aboutThisProgramAToolStripMenuItem";
			this.aboutThisProgramAToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			this.aboutThisProgramAToolStripMenuItem.Text = "About This Program(&A)";
			this.aboutThisProgramAToolStripMenuItem.Click += new System.EventHandler(this.aboutThisProgramAToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(511, 117);
			this.Controls.Add(this.recheckButton);
			this.Controls.Add(this.helloButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.gradeComboBox);
			this.Controls.Add(this.numberComboBox);
			this.Controls.Add(this.adapterComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.radioButtonsGroupBox);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Configuration TCP/IP";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.radioButtonsGroupBox.ResumeLayout(false);
			this.radioButtonsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainFormAdapterBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormNumberBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormGradeBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton staticRadioButton;
		private System.Windows.Forms.RadioButton dynamicRadioButton;
		private System.Windows.Forms.GroupBox radioButtonsGroupBox;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox adapterComboBox;
		private System.Windows.Forms.ComboBox numberComboBox;
		private System.Windows.Forms.BindingSource mainFormAdapterBindingSource;
		private System.Windows.Forms.ComboBox gradeComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button helloButton;
		private System.Windows.Forms.BindingSource mainFormNumberBindingSource;
		private System.Windows.Forms.BindingSource mainFormGradeBindingSource;
		private System.Windows.Forms.Button recheckButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitXToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpTopicsHToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem aboutThisProgramAToolStripMenuItem;
	}
}

