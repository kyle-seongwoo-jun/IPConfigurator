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
			this.staticRadioButton = new System.Windows.Forms.RadioButton();
			this.dynamicRadioButton = new System.Windows.Forms.RadioButton();
			this.radioButtonsGroupBox = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.radioButtonsGroupBox.SuspendLayout();
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
			this.staticRadioButton.TabStop = true;
			this.staticRadioButton.Text = "Static";
			this.staticRadioButton.UseVisualStyleBackColor = true;
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
			this.dynamicRadioButton.TabStop = true;
			this.dynamicRadioButton.Text = "Dynamic";
			this.dynamicRadioButton.UseVisualStyleBackColor = true;
			// 
			// radioButtonsGroupBox
			// 
			this.radioButtonsGroupBox.Controls.Add(this.staticRadioButton);
			this.radioButtonsGroupBox.Controls.Add(this.dynamicRadioButton);
			this.radioButtonsGroupBox.Location = new System.Drawing.Point(12, 5);
			this.radioButtonsGroupBox.Name = "radioButtonsGroupBox";
			this.radioButtonsGroupBox.Size = new System.Drawing.Size(151, 47);
			this.radioButtonsGroupBox.TabIndex = 2;
			this.radioButtonsGroupBox.TabStop = false;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(177, 82);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Grade";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "Number";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "1st",
            "2nd"});
			this.comboBox1.Location = new System.Drawing.Point(72, 60);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(91, 20);
			this.comboBox1.TabIndex = 8;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(72, 84);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(91, 20);
			this.comboBox2.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(264, 117);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.radioButtonsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.radioButtonsGroupBox.ResumeLayout(false);
			this.radioButtonsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton staticRadioButton;
		private System.Windows.Forms.RadioButton dynamicRadioButton;
		private System.Windows.Forms.GroupBox radioButtonsGroupBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
	}
}

