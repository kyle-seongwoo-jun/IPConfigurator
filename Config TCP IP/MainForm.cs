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
				dynamicRadioButton.Checked = networkAdapterConfinguration.IsDynamic(adapterComboBox.SelectedItem as string);
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
				//TODO: This method has return value... 
				networkAdapterConfinguration.ToDynamicIP(adapterComboBox.SelectedItem as string);
				MessageBox.Show("End!");
			}
			else
			{
				MessageBox.Show("Please Check Any Button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void helloButton_Click(object sender, EventArgs e)
		{
			new HelloForm().Show();
		}

		private void recheckButton_Click(object sender, EventArgs e)
		{
			mainFormAdapterBindingSource.DataSource = networkAdapterConfinguration.FindNetworkAdapter();
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
	}
}
