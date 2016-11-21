using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace IPConfigurator
{
	public partial class MainForm : Form
	{
		NetworkAdapterConfigurator networkAdapterConfingurator;
		List<NetworkAdapter> adapters;

		/// <summary>
		/// Constructor
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			networkAdapterConfingurator = new NetworkAdapterConfigurator();
			adapters = networkAdapterConfingurator.NetworkAdapters;
		}

		#region Event Listener

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Initialize BingingSource
			adapterBindingSource.DataSource = adapters;
			numberBindingSource.DataSource = Enumerable.Range(1, 80);
			gradeBindingSource.DataSource = Enumerable.Range(1, 2);

			// Initialize component's state 
			if (adapterComboBox.SelectedItem as NetworkAdapter != null)
			{
				var adapter = adapterComboBox.SelectedItem as NetworkAdapter;

				if (adapter.IsDynamic)
				{
					setEnabled(NetworkAdapterStatus.Dynamic);
				}
				else
				{
					setEnabled(NetworkAdapterStatus.Static);
				}
			}
			else
			{
				setEnabled(NetworkAdapterStatus.None);
			}

			try
			{
				// Load	previous data
				using (FileStream fs = File.OpenRead(@"C:\ipconfig.dat"))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						gradeComboBox.SelectedItem = br.ReadInt32();
						numberComboBox.SelectedItem = br.ReadInt32();
					}
				}
			}
			catch (FileNotFoundException) { /* First run */ }
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			if (staticRadioButton.Checked)
			{
				int grade = (int)gradeComboBox.SelectedItem;
				int number = (int)numberComboBox.SelectedItem;

				var adapter = adapterComboBox.SelectedItem as NetworkAdapter;
				adapter.ToStaticIP("10.156.145." + getIdentificationNumber(grade, number));
				MessageBox.Show("Configured.");
			}
			else if (dynamicRadioButton.Checked)
			{
				try
				{
					var adapter = adapterComboBox.SelectedItem as NetworkAdapter;
					adapter.ToDynamicIP();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				MessageBox.Show("Configured.");
			}
			else
			{
				MessageBox.Show("Please Check Any Button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void checkIPButton_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			var adapter = adapterComboBox.SelectedItem as NetworkAdapter;
			foreach (var item in adapter.IPInformation)
			{
				sb.AppendLine(item.Key + " : " + item.Value);
			}

			MessageBox.Show(sb.ToString());
		}

		private void recheckButton_Click(object sender, EventArgs e)
		{
			adapterBindingSource.DataSource = networkAdapterConfingurator.NetworkAdapters;

			if (adapterComboBox.SelectedItem as NetworkAdapter != null)
			{
				var adapter = adapterComboBox.SelectedItem as NetworkAdapter;

				if (adapter.IsDynamic)
				{
					setEnabled(NetworkAdapterStatus.Dynamic);
				}
				else
				{
					setEnabled(NetworkAdapterStatus.Static);
				}
			}
			else
			{
				setEnabled(NetworkAdapterStatus.None);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			using (FileStream file = File.Create(@"C:\ipconfig.dat"))
			{
				using (BinaryWriter writer = new BinaryWriter(file))
				{
					int grade = (int)gradeComboBox.SelectedItem;
					int number = (int)numberComboBox.SelectedItem;

					writer.Write(grade);
					writer.Write(number);
				}
			}
		}

		private void aboutThisProgramAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutForm().Show();
		}

		private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void helpTopicsHToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("1. Select Static or Dynamic.\n2. Select your grade, and laptop number.\n3. And.. Just Start!!! \n", "How to use it!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void staticRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton.Checked)
			{
				setEnabled(NetworkAdapterStatus.Static);
			}
			else
			{
				setEnabled(NetworkAdapterStatus.Dynamic);
			}
		}

		private void dynamicRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton.Checked)
			{
				setEnabled(NetworkAdapterStatus.Dynamic);
			}
			else
			{
				setEnabled(NetworkAdapterStatus.Static);
			}
		}

		private void adapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		#endregion

		/// <summary>
		/// 개인의 아이피 주소를 가져오는 함수
		/// </summary>
		/// <param name="grade">학년</param>
		/// <param name="number">노트북 번호</param>
		/// <returns>아이피 4번째 자리 (10.156.145.xxx)</returns>
		private int getIdentificationNumber(int grade, int number)
		{
			int id = 20;
			
			if(grade == 1)
			{
				id += 80;
			}

			id += number;

			return id;
		}

		enum NetworkAdapterStatus
		{
			Static, Dynamic, None
		}

		private void setEnabled(NetworkAdapterStatus status)
		{
			switch (status)
			{
				case NetworkAdapterStatus.Static:
					staticRadioButton.Checked = true;
					dynamicRadioButton.Checked = false;
					radioButtonsGroupBox.Enabled = true;
					gradeComboBox.Enabled = true;
					numberComboBox.Enabled = true;
					break;

				case NetworkAdapterStatus.Dynamic:
					staticRadioButton.Checked = false;
					dynamicRadioButton.Checked = true;
					radioButtonsGroupBox.Enabled = true;
					gradeComboBox.Enabled = false;
					numberComboBox.Enabled = false;
					break;

				case NetworkAdapterStatus.None:
					staticRadioButton.Checked = false;
					dynamicRadioButton.Checked = false;
					radioButtonsGroupBox.Enabled = false;
					gradeComboBox.Enabled = false;
					numberComboBox.Enabled = false;
					break;
			}
		}

	}
}
