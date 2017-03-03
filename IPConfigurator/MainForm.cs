using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using IPConfigurator.Properties;

namespace IPConfigurator
{
	public partial class MainForm : Form
	{
		#region Fields

		NetworkAdapterConfigurator networkAdapterConfingurator;
		List<NetworkAdapter> adapters;

		#endregion

		#region Properties

		NetworkAdapter SelectedAdapter
		{
			get
			{
				return AdapterComboBox.SelectedItem as NetworkAdapter;
			}
		}

		string IPAddress
		{
			get
			{
				int grade = (int)GradeComboBox.SelectedValue;
				int class_ = (int)ClassComboBox.SelectedValue;
				int number = (int)NumberComboBox.SelectedValue;

				// TODO: 내일 종현쌤한테 물어보기
				var third = new[] { new[] { 147, 147, 147, 147 }, new[] { 145, 145, 146, 146 }, new[] { 145, 145, 146, 146 } };
				var fourth = new[] { new[] { 100, 121, 141, 161 }, new[] { 100, 120, 100, 140 }, new[] { 150, 169, 120, 160 } };

				return $"10.156.{third[grade - 1][class_ - 1]}.{fourth[grade - 1][class_ - 1] + number}";
			}
		}

		string GateWay
		{
			get
			{
				int grade = (int)GradeComboBox.SelectedValue;
				int class_ = (int)ClassComboBox.SelectedValue;

				var third = new[] { new[] { 147, 147, 147, 147 }, new[] { 145, 145, 146, 146 }, new[] { 145, 145, 146, 146 } };

				return $"10.156.{third[grade - 1][class_ - 1]}.1";
			}
		}

		Settings Setting
		{
			get
			{
				return Settings.Default;
			}
		}

		#endregion

		#region Constructor

		public MainForm()
		{
			InitializeComponent();
			networkAdapterConfingurator = new NetworkAdapterConfigurator();
			adapters = networkAdapterConfingurator.NetworkAdapters;
		}

		#endregion

		#region Event Listeners
		private void MainForm_Load(object sender, EventArgs e)
		{
			// Initialize BingingSource
			AdapterBindingSource.DataSource = adapters;
			GradeBindingSource.DataSource = Enumerable.Range(1, 3);
			ClassBindingSource.DataSource = Enumerable.Range(1, 4);
			NumberBindingSource.DataSource = Enumerable.Range(1, 20);

			// Initialize component's state 
			SetComponentByAdapter();

			GradeComboBox.SelectedItem = Setting.Grade;
			ClassComboBox.SelectedItem = Setting.Class;
			NumberComboBox.SelectedItem = Setting.Number;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Setting.Grade = (int)GradeComboBox.SelectedItem;
			Setting.Class = (int)ClassComboBox.SelectedItem;
			Setting.Number = (int)NumberComboBox.SelectedItem;
			Setting.Save();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (StaticRadioButton.Checked)
			{
				int grade = (int)GradeComboBox.SelectedItem;
				int number = (int)NumberComboBox.SelectedItem;

				SelectedAdapter.ToStaticIP(IPAddress, gateway: GateWay);
				MessageBox.Show("Configured.");
			}
			else if (DynamicRadioButton.Checked)
			{
				SelectedAdapter.ToDynamicIP();
				MessageBox.Show("Configured.");
			}
			else
			{
				MessageBox.Show("Please Check Any Button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void IPButton_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in SelectedAdapter.IPInformation)
			{
				sb.AppendLine(item.Key + " : " + item.Value);
			}

			MessageBox.Show(sb.ToString());
		}

		private void ReloadButton_Click(object sender, EventArgs e)
		{
			AdapterBindingSource.DataSource = networkAdapterConfingurator.NetworkAdapters;

			SetComponentByAdapter();
		}

		private void AboutThisProgramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutBox().ShowDialog();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void HelpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("1. Select Static or Dynamic.\n2. Select your grade, and laptop number.\n3. And.. Just Start!!! \n", "How to use it!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void StaticRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton.Checked)
			{
				SetComponentBy(NetworkAdapterStatus.Static);
			}
			else
			{
				SetComponentBy(NetworkAdapterStatus.Dynamic);
			}
		}

		private void AdapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetComponentByAdapter();
		}

		#endregion

		#region Methods

		private void SetComponentByAdapter()
		{
			if (SelectedAdapter != null)
			{
				if (SelectedAdapter.IsDynamic)
				{
					SetComponentBy(NetworkAdapterStatus.Dynamic);
				}
				else
				{
					SetComponentBy(NetworkAdapterStatus.Static);
				}
			}
			else
			{
				SetComponentBy(NetworkAdapterStatus.None);
			}
		}

		private enum NetworkAdapterStatus
		{
			Static, Dynamic, None
		}

		private void SetComponentBy(NetworkAdapterStatus status)
		{
			switch (status)
			{
				case NetworkAdapterStatus.Static:
					StaticRadioButton.Checked = true;
					DynamicRadioButton.Checked = false;
					RadioButtonGroupBox.Enabled = true;
					GradeComboBox.Enabled = true;
					ClassComboBox.Enabled = true;
					NumberComboBox.Enabled = true;
					break;

				case NetworkAdapterStatus.Dynamic:
					StaticRadioButton.Checked = false;
					DynamicRadioButton.Checked = true;
					RadioButtonGroupBox.Enabled = true;
					GradeComboBox.Enabled = false;
					ClassComboBox.Enabled = false;
					NumberComboBox.Enabled = false;
					break;

				case NetworkAdapterStatus.None:
					StaticRadioButton.Checked = false;
					DynamicRadioButton.Checked = false;
					RadioButtonGroupBox.Enabled = false;
					GradeComboBox.Enabled = false;
					ClassComboBox.Enabled = false;
					NumberComboBox.Enabled = false;
					break;
			}
		}

		#endregion
	}
}
