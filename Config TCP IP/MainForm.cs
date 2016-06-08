using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ClassLibrary;
using System.Management;
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

	class NetworkAdapterConfiguration
	{
		ManagementClass adapterConfig;
		ManagementObjectCollection networkCollection;

		public NetworkAdapterConfiguration()
		{
			adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
			networkCollection = adapterConfig.GetInstances();
		}

		public string[] FindNetworkAdapter()
		{
			networkCollection = adapterConfig.GetInstances();
			List<string> temp = new List<string>();

			foreach (ManagementObject adapter in networkCollection)
			{
				if ((bool)adapter["IPEnabled"])
				{
					temp.Add(adapter["Description"] as string);
				}
			}
			return temp.ToArray();
		}

		public bool IsDynamic(string adapterName)
		{
			foreach (ManagementObject adapter in networkCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					return (bool)adapter["DHCPEnabled"];
				}
			}

			// TODO: Make new Exception class
			throw new Exception();
		}

		public void ToStaticIP(string adapterName, string ipAddress, string subnetMask = "255.255.255.0", string gateway = "10.156.145.1", string DNS = "210.111.226.7,210.111.226.8")
		{
			foreach (ManagementObject adapter in networkCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					// Set IPAddress and Subnet Mask
					ManagementBaseObject newAddress = adapter.GetMethodParameters("EnableStatic");
					newAddress["IPAddress"] = new string[] { ipAddress };
					newAddress["SubnetMask"] = new string[] { subnetMask };

					// Set DefaultGateway
					ManagementBaseObject newGateway = adapter.GetMethodParameters("SetGateways");
					newGateway["DefaultIPGateway"] = new string[] { gateway };
					newGateway["GatewayCostMetric"] = new int[] { 1 };

					// Set DNS server 
					ManagementBaseObject newDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					newDNS["DNSServerSearchOrder"] = DNS.Split(',');

					// Configurate
					adapter.InvokeMethod("EnableStatic", newAddress, null);
					adapter.InvokeMethod("SetGateways", newGateway, null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);

					//TODO: These three Method has return value...
				}
			}
		}

		public void ToDynamicIP(string adapterName)
		{
			foreach (ManagementObject adapter in networkCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					ManagementBaseObject nullDNS = adapter.GetMethodParameters("SetDNSServerSearchOrder");
					nullDNS["DNSServerSearchOrder"] = null;

					adapter.InvokeMethod("EnableDHCP", null);
					adapter.InvokeMethod("SetDNSServerSearchOrder", nullDNS, null);

					return;
				}
			}

			throw new Exception();
		}

		public string[] GetIP(string adapterName)
		{
			List<string> list = new List<string>();

			foreach (ManagementObject adapter in networkCollection)
			{
				if (adapterName.Equals(adapter["Description"]))
				{
					string ip = (adapter["IPAddress"] as string[])[0];
					string subnetMask = (adapter["IPSubnet"] as string[])[0];
					string gateway = (adapter["DefaultIPGateway"] as string[])[0];
					string[] dns = (adapter["DNSServerSearchOrder"] as string[]);

					list.Add("IP Address : " + ip);
					list.Add("Subnet Mask : " + subnetMask);
					list.Add("Default Gateway : " + gateway);
					list.Add("DNS Server : " + dns[0]);

					if (dns.Length > 1)
					{
						list[3] += ", " + dns[1];
					}

					return list.ToArray();
				}
			}

			throw new Exception();
		}
	}
}
