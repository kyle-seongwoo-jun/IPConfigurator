using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.IO;

namespace Config_TCP_IP
{
	public partial class MainForm : Form
	{
		NetworkAdapterConfiguration networkAdapterConfinguration;

		public MainForm()
		{
			InitializeComponent();
			networkAdapterConfinguration = new NetworkAdapterConfiguration();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			mainFormAdapterBindingSource.DataSource = networkAdapterConfinguration.FindNetworkAdapter();

			int[] number = new int[80];
			for(int i = 0; i < number.Length; i++)
			{
				number[i] = i + 1;
			}

			mainFormNumberBindingSource.DataSource = number;
			mainFormGradeBindingSource.DataSource = new int[] { 1, 2/*, 3*/ };

			if (adapterComboBox.SelectedItem as string != null)
			{
				if (networkAdapterConfinguration.IsDynamic(adapterComboBox.SelectedItem as string))
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
				using (FileStream fs = File.OpenRead(@"C:\ipconfig.dat"))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						gradeComboBox.SelectedItem = br.ReadInt32();
						numberComboBox.SelectedItem = br.ReadInt32();
					}
				}
			}
			catch (FileNotFoundException) { /* This case is for when starting program first. */ }
		}

		private int getIdentificationNumber(int grade, int number)
		{
			int temp = 20;
			
			if(grade == 1)
			{
				temp += 80;
			}

			temp += number;

			return temp;
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			if (staticRadioButton.Checked)
			{
				int grade = (int)gradeComboBox.SelectedItem;
				int number = (int)numberComboBox.SelectedItem;

				networkAdapterConfinguration.ToStaticIP(adapterComboBox.SelectedItem as string, "10.156.145." + getIdentificationNumber(grade, number));
				MessageBox.Show("End!");
			}
			else if (dynamicRadioButton.Checked)
			{
				try
				{
					networkAdapterConfinguration.ToDynamicIP(adapterComboBox.SelectedItem as string);

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				MessageBox.Show("End!");
			}
			else
			{
				MessageBox.Show("Please Check Any Button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void helloButton_Click(object sender, EventArgs e)
		{
			foreach(string s in networkAdapterConfinguration.GetIP(adapterComboBox.SelectedItem as string))
			{
				MessageBox.Show(s);
			}
		}

		private void recheckButton_Click(object sender, EventArgs e)
		{
			mainFormAdapterBindingSource.DataSource = networkAdapterConfinguration.FindNetworkAdapter();

			if (adapterComboBox.SelectedItem as string != null)
			{
				if (networkAdapterConfinguration.IsDynamic(adapterComboBox.SelectedItem as string))
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
			using (FileStream fs = File.Create(@"C:\ipconfig.dat"))
			{
				using (BinaryWriter bw = new BinaryWriter(fs))
				{
					int grade = (int)gradeComboBox.SelectedItem;
					int number = (int)numberComboBox.SelectedItem;

					bw.Write(grade);
					bw.Write(number);
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
			RadioButton rb = sender as RadioButton;
			if (rb.Checked)
			{
				setEnabled(NetworkAdapterStatus.Static);
			}
			else
			{
				setEnabled(NetworkAdapterStatus.Dynamic);
			}
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

		private void dynamicRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			if (rb.Checked)
			{
				setEnabled(NetworkAdapterStatus.Dynamic);
			}
			else
			{
				setEnabled(NetworkAdapterStatus.Static);
			}
		}
	}
}
